using System;
using vs4mac_dotnet_standard_library;

namespace vs4mac_console1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var randomNumber = Magicmatics.GimmeRandomNumber();

            Console.WriteLine($"Hello World! Your random number is: {randomNumber}");
        }
    }
}
