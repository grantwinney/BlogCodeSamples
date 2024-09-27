using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GhostSharp;
using GhostSharp.Entities;
using GhostSharp.Enums;
using GhostSharp.QueryParams;
using Newtonsoft.Json;
using Tweetinvi;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;

namespace TweetRandomFeedItem
{
    class Program
    {
        private const int TWITTER_URL_SIZE = 23;
        private const int MAX_TWEET_LENGTH = 280;

        private static readonly string API_URL = Helper.GetEnv<string>("API_URL");
        private static readonly string ADMIN_API_KEY = Helper.GetEnv<string>("ADMIN_API_KEY");
        private static readonly string TWITTER_CONSUMER_KEY = Helper.GetEnv<string>("TWITTER_CONSUMER_KEY");
        private static readonly string TWITTER_CONSUMER_SECRET = Helper.GetEnv<string>("TWITTER_CONSUMER_SECRET");
        private static readonly string TWITTER_USER_ACCESS_TOKEN = Helper.GetEnv<string>("TWITTER_USER_ACCESS_TOKEN");
        private static readonly string TWITTER_USER_ACCESS_TOKEN_SECRET = Helper.GetEnv<string>("TWITTER_USER_ACCESS_TOKEN_SECRET");
        private static readonly string[] TAGS_TO_TWEET = Helper.GetEnv<string>("TAGS_TO_TWEET", "").Split(',');
        private static readonly string[] TAGS_TO_REMOVE = Helper.GetEnv<string>("TAGS_TO_REMOVE", "").Split(',');
        private static readonly int POST_RETRIEVAL_LIMIT = Helper.GetEnv<int>("POST_RETRIEVAL_LIMIT", "9999999");
        private static readonly int TWITTER_MAX_TAG_COUNT = Helper.GetEnv<int>("TWITTER_MAX_TAG_COUNT", "3");
        private static readonly bool FACTOR_IN_AGE_OF_POST = Helper.GetEnv<bool>("FACTOR_IN_AGE_OF_POST", "false");

        static readonly Random rnd = new Random();
        static readonly GhostAdminAPI api = new GhostAdminAPI(API_URL, ADMIN_API_KEY);

        public static async Task Main()
        {
            var allPosts = api.GetPosts(new PostQueryParams
            {
                Limit = POST_RETRIEVAL_LIMIT,
                Fields = (FACTOR_IN_AGE_OF_POST ? PostFields.Id | PostFields.PublishedAt : PostFields.Id) | PostFields.Status,
            }).Posts.Where(p => p.Status == "published").ToList();

            if (!allPosts.Any())
            {
                Console.WriteLine("No posts! Nothing to tweet...");
                return;
            }

            await SendTweet(CreateMessage(PickRandomPost(allPosts)));
        }

        static Post PickRandomPost(List<Post> posts)
        {
            var selectedIds = new HashSet<string>();

            while (true)
            {
                string randomPostId = "";
                do
                {
                    randomPostId = FACTOR_IN_AGE_OF_POST
                        ? GetRandomPostIdWeightedOnAge(posts)
                        : posts[rnd.Next(0, posts.Count())].Id;
                }
                while (selectedIds.Contains(randomPostId));

                selectedIds.Add(randomPostId);

                var randomPost = api.GetPostById(randomPostId);

                if (!TAGS_TO_TWEET.Any() || randomPost.Tags.Select(tag => tag.Slug).Intersect(TAGS_TO_TWEET).Any())
                    return randomPost;
            }
        }

        static string GetRandomPostIdWeightedOnAge(List<Post> posts)
        {
            var earliestPublishDate = posts.Last().PublishedAt;

            var postsCount = posts.Count();
            var postIdsAndPubWeights = posts.Select((p, i) => Tuple.Create(posts[i].Id, ((posts[i].PublishedAt ?? DateTime.MinValue) - earliestPublishDate).Value.Days * (postsCount - i)));
            var totalPubWeights = postIdsAndPubWeights.Sum(p => p.Item2);
            var randomPubWeight = rnd.Next(0, totalPubWeights);

            foreach (var p in postIdsAndPubWeights)
            {
                if (randomPubWeight <= p.Item2)
                    return p.Item1;

                randomPubWeight -= p.Item2;
            }

            return null;  // req to compile, but won't happen unless there are no posts
        }

        static string CreateMessage(Post post)
        {
            var captionSources = new List<string> { post.TwitterDescription, post.MetaDescription, post.Title };

            var caption = captionSources.First(cs => !string.IsNullOrWhiteSpace(cs));

            var remainingSpaceForTags = MAX_TWEET_LENGTH - (caption.Length + 1 + TWITTER_URL_SIZE);

            var tags = post.Tags.Where(x => !TAGS_TO_REMOVE.Contains(x.Slug))
                                .Take(TWITTER_MAX_TAG_COUNT)
                                .Select(t => Helper.SanitizeTagName(t.Name));
          
            var tagsFlat = "";
            foreach (var t in tags)
            {
                if ($"{tagsFlat} {t}".Length > remainingSpaceForTags)
                    break;
                
                tagsFlat += $" {t}";
            }

            return $"{caption}{tagsFlat}\r\n{post.Url}";
        }

        static async Task SendTweet(string message)
        {
            var client = new TwitterClient(TWITTER_CONSUMER_KEY, TWITTER_CONSUMER_SECRET, TWITTER_USER_ACCESS_TOKEN, TWITTER_USER_ACCESS_TOKEN_SECRET);

            //await userClient.Tweets.PublishTweetAsync(message);

            // The TweetInvi library seems to be abandoned and PublishTweetAsync isn't working correctly,
            // but someone posted a workaround: https://github.com/linvi/tweetinvi/issues/1147#issuecomment-1173174302
            var result = await client.Execute.AdvanceRequestAsync(
                (ITwitterRequest request) =>
                {
                    var jsonBody = client.Json.Serialize(new TweetV2PostRequest { Text = message });

                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    request.Query.Url = "https://api.twitter.com/2/tweets";
                    request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                    request.Query.HttpContent = content;
                }
            );

            if (result.Response.IsSuccessStatusCode)
                Console.WriteLine($"Tweeted message:\r\n{message}\r\n");
            else
                Console.WriteLine($"Error posting tweet: {result.Content}\r\n\r\nOriginal tweet: {message}");
        }
    }

    /// <summary>
    /// There are a lot more fields according to:
    /// https://developer.twitter.com/en/docs/twitter-api/tweets/manage-tweets/api-reference/post-tweets
    /// but these are the ones we care about for our use case.
    /// </summary>
    public class TweetV2PostRequest
    {
        /// <summary>
        /// The text of the tweet to post.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;
    }
}
