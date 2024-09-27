using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using Tweetinvi;

namespace TweetRandomFeedItem
{
    class Program
    {
        const string DEFAULT_MAX_TAG_COUNT = "3";
        const int TWITTER_URL_SIZE = 23;
        const int MAX_TWEET_LENGTH = 280;

        static Random random = new Random();

        public static async void Main()
        {
            var message = CreateMessageFromRandomFeedItem();

            await SendTweet(message);

            Console.WriteLine($"Tweeted message:\r\n\r\n{message}");
        }

        static string CreateMessageFromRandomFeedItem()
        {
            var ghostUri = Helper.GetEnv<string>("RSS_URI");
            var maxTagCount = Helper.GetEnv<int>("TWITTER_MAX_TAG_COUNT", DEFAULT_MAX_TAG_COUNT);
            var maxItemsToRead = Helper.GetEnv<int>("RSS_ITEM_RETRIEVAL_LIMIT", Int32.MaxValue.ToString());

            var pattern = new Regex("[- ]");
            var entries = new List<ISyndicationItem>();

            using (var xmlReader = XmlReader.Create(ghostUri))
            {
                var feedReader = new RssFeedReader(xmlReader);

                var itemsRead = 0;
                while (feedReader.Read().Result && itemsRead < maxItemsToRead)
                {
                    if (feedReader.ElementType == SyndicationElementType.Item)
                    {
                        entries.Add(feedReader.ReadItem().Result);
                        itemsRead++;
                    }
                }
            }

            var selectedEntry = entries[random.Next(0, entries.Count - 1)];

            var remainingSpaceForTags = MAX_TWEET_LENGTH - (selectedEntry.Title.Length + 1 + TWITTER_URL_SIZE);

            var tags = selectedEntry.Categories.Take(maxTagCount).Select(x => $"#{pattern.Replace(x.Name, "_").Replace("#", "sharp").Replace(".", "dot")}");

            var tagsFlat = "";
            foreach (var t in tags)
            {
                if ($"{tagsFlat} {t}".Length > remainingSpaceForTags)
                    break;

                tagsFlat += $" {t}";
            }

            return $"{selectedEntry.Title}{tagsFlat}\r\n{selectedEntry.Links.ToList()[0].Uri}";
        }

        static async Task SendTweet(string message)
        {
            var consumerKey = Helper.GetEnv<string>("TWITTER_CONSUMER_KEY");
            var consumerSecret = Helper.GetEnv<string>("TWITTER_CONSUMER_SECRET");
            var userAccessToken = Helper.GetEnv<string>("TWITTER_USER_ACCESS_TOKEN");
            var userAccessTokenSecret = Helper.GetEnv<string>("TWITTER_USER_ACCESS_TOKEN_SECRET");

            var userClient = new TwitterClient(consumerKey, consumerSecret, userAccessToken, userAccessTokenSecret);

            await userClient.Tweets.PublishTweetAsync(message);

            Console.WriteLine($"Tweeted message:\r\n{message}\r\n");
        }
    }
}
