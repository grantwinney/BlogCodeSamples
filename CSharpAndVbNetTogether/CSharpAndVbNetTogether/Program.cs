using System;
using GettinFunkyshunal;
using VisualBasicGuiInterface;

namespace CSharpAndVbNetTogether
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Track this IP!!! {IPTracker.TrackIpAddress()} \r\n");
            Console.WriteLine($"Sum: {MathStuff.add(2, 3)}");
            Console.WriteLine($"Diff: {MathStuff.subtract(2, 3)}");
            Console.ReadLine();
        }
    }
}
