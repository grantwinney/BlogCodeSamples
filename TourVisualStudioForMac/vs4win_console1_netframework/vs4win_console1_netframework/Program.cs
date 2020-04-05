using System;
using vs4mac_dotnet_standard_library;

namespace vs4win_console1_netframework
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomNumber = Magicmatics.GimmeRandomNumber();

            Console.WriteLine($"Hello World! Your random number is: {randomNumber}");
            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
