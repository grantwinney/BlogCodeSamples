using AttributesExamples;
using System;

namespace DemoAttributeExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumAsBitFieldDemo();

            Console.ReadLine();
        }

        static void ParsingConfigurationFileDemo()
        {
            var settings = Application.LoggingConfig;

            Console.WriteLine($"Log Name: {settings.LogName}");
            Console.WriteLine($"Log Location: {settings.LogPath}");
            Console.WriteLine($"Severity Level: {settings.SeverityLevel}");
            Console.WriteLine($"Logging {(settings.LoggingEnabled ? @"is" : @"is not")} enabled.");
        }

        static void PlannedCodeObsolescenceDemo()
        {
            var p = new PlannedCodeObsolescence();

            p.SetName("Tiny Tim");

            // p.AgeSet(5);
        }

        static void EnumAsBitFieldDemo()
        {
            var prefContactMethods = PreferredContactMethods.Email | PreferredContactMethods.FlooPowder;

            if (prefContactMethods == PreferredContactMethods.None)
                Console.WriteLine("User hates people. :(");    // won't print

            if (prefContactMethods.HasFlag(PreferredContactMethods.LandPhone))
                Console.WriteLine("What's a landph one? :/");  // also won't print

            if (prefContactMethods.HasFlag(PreferredContactMethods.CellPhone)
                || prefContactMethods.HasFlag(PreferredContactMethods.Email))
                Console.WriteLine("Aren't we modern? :p");     // should print

            prefContactMethods |= PreferredContactMethods.Owl;

            if (prefContactMethods.HasFlag(PreferredContactMethods.Wizard))
                Console.WriteLine("You're a wizard Harry!! ~:›");  // this too
            }
    }
}
