using System;
using static System.Environment;

namespace GetKnownFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFolderPath(SpecialFolder.MyDocuments));
            Console.ReadLine();
        }
    }
}
