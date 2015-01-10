using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace AsyncAndPlinq112013
{
    public class Class1
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        static void Main()
        {
            Stopwatch.Start();
            PLinqTest();
            Stopwatch.Stop();
            Console.WriteLine("Total execution time: {0}",
              Stopwatch.ElapsedMilliseconds / 1000m);
            Console.Read();
        }

        static void PLinqTest()
        {
            var numbers = new[] { 1, 2, 3, 4 };
            numbers.AsParallel().Select(SomeLongComputation).ToList();
        }

        static int SomeLongComputation(int n)
        {
            for (var i = 0; i <= 5; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(string.Concat(n, ":", i));
            }
            return -1;
        }
    }

    public class Class2
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();
        private static CancellationToken cancellationToken;

        static void Main()
        {
            new Timer(x => cancellationToken
                             = new CancellationToken(true), "hi", 250, 10000);
            Stopwatch.Start();
            PLinqTest();
            Stopwatch.Stop();
            Console.WriteLine("Total execution time: {0}",
                              Stopwatch.ElapsedMilliseconds / 1000m);
            Console.Read();
        }

        static void PLinqTest()
        {
            var numbers = new[] { 1, 2, 3, 4 };
            numbers.AsParallel().WithCancellation(cancellationToken)
                                .Select(SomeLongComputation).ToList();
        }

        static int SomeLongComputation(int n)
        {
            for (var i = 0; i <= 5; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                Thread.Sleep(100);
                Console.WriteLine(string.Concat(n, ":", i));
            }
            return -1;
        }
    }
}
