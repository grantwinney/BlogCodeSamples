using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;
using System;

namespace AmazonProductAdvertSig1
{
    class Program
    {
        static void Main(string[] args)
        {
            var authentication = new AmazonAuthentication
            {
                AccessKey = "your-access-key",
                SecretKey = "your-secret-key"
            };

            var wrapper = new AmazonWrapper(authentication, AmazonEndpoint.US, "your-store-id");
            wrapper.ErrorReceived += (err) => Console.WriteLine($"Error {err.Error.Code}: {err.Error.Message}");
            wrapper.XmlReceived += (xml) => Console.WriteLine($"Received: {xml}");

            // Search for products
            //var result = wrapper.Search("raspberry pi", AmazonSearchIndex.Electronics, AmazonResponseGroup.Small);
            //Console.WriteLine(result.Items.TotalResults);

            // Search for a specific item
            var result = wrapper.Lookup("B07BQFX4SB");
            Console.WriteLine(result.Items.Item[0].DetailPageURL);

            Console.ReadLine();
        }
    }
}
