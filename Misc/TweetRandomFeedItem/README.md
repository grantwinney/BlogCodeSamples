# Tweet a Random RSS Feed Item

***Using [AWS Lambda](https://aws.amazon.com/lambda/) and [Tweetinvi](https://github.com/linvi/tweetinvi)***

This project is a slight modification of [my last one](https://github.com/grantwinney/BlogCodeSamples/tree/master/Misc/TweetRandomPostFromAGhostBlog), replacing reading posts via the Ghost API to a more general parsing of RSS feeds. I wanted to create something that would work for *any* blog... or anything else that generates an RSS feed.

## Usage

This is a C# console you can run from AWS Lambda. Schedule it to run as often as you like using Lambda's [cron scheduling](https://docs.aws.amazon.com/lambda/latest/dg/tutorial-scheduled-events-schedule-expressions.html) capabilities.

If you'd like to read more about it, [I wrote a blog post about it too](https://grantwinney.com/using-aws-lambda-to-tweet-random-posts-from-an-rss-feed/).

### Getting the code

1. Clone this repo: `git clone https://github.com/grantwinney/BlogCodeSamples.git`
2. Find the project under "Misc/TweetRandomFeedItem" and build it, either in Visual Studio or at the command line.
3. Find the `bin` directory on disk, and drill down until you get to the assemblies (dll files). Most likely: `bin/Debug/netcoreapp2.0`
4. Zip up the contents of the inner-most directory, but not the directory itself. _(e.g. just select all the files_ inside _`netcoreapp2.0`.)_

### Setting up AWS Lambda

Now you need to create a new AWS Lambda job. [Check this out](https://victoria.dev/archive/running-a-free-twitter-bot-on-aws-lambda/#setting-up-aws-lambda) for a brief intro to setting up a job.

1. Create a new function and choose `C# (.NET Core 2.0)` for the runtime. _(this may change as new versions are released)_
2. The name of the function, and the role it makes you create, don't matter.
3. Upload the zip file you created above.
4. Set the handler as `TweetRandomFeedItem::TweetRandomFeedItem.Program::Main`
5. Under "Basic settings", decrease the memory to 128MB and increase the timeout to a minute. For me, it generally takes about 15-20 seconds to run, and uses less than 100MB of memory. You may have to play with the settings a bit.
6. Set the following environment variables:

#### Environment Variables

I use quite a few environment variables, so credentials and other settings can easily be changed between runs, without having to recompile the code and upload it again.

| Field        | Required           | Description  |
| ------------- |:-------------:| -----|
| `RSS_URI`   | Yes | The RSS feed to read in, like: `https://grantwinney.com/rss/` |
| `RSS_ITEM_RETRIEVAL_LIMIT`      | No | Specify the number of posts you want to retrieve.<br><br>If you omit this, or leave the value empty, the app will read the entire RSS feed. |
| `TWITTER_CONSUMER_KEY`<br>`TWITTER_CONSUMER_SECRET`<br>`TWITTER_USER_ACCESS_TOKEN`<br>`TWITTER_USER_ACCESS_TOKEN_SECRET`      | Yes      | These values all come from your Twitter account. You need to create a new app to get these values, which allows you to post tweets. |
| `TWITTER_MAX_TAG_COUNT` | No      | Although tag spamming is somewhat prevalent on Facebook, and even more-so on Instagram, I don't see a lot of it on Twitter. If you tend to use a lot of tags for posts on your blog, then you can limit how many of those transfer to your tweet.<br><br>If you omit this, or leave the value empty, the app will use the first 3 tags. |
