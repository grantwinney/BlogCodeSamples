using System;
using System.IO;
using System.Threading.Tasks;

namespace FileShareExample
{
    class Program
    {
        static void Main(string[] _)
        {
            using (var writer = new StreamWriter(new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)))
            {
                Task.WaitAll(Task.Factory.StartNew(() => WriteToFile("thread1", writer)),
                             Task.Factory.StartNew(() => WriteToFile("thread2", writer)));
            }
        }

        static void WriteToFile(string threadName, StreamWriter writer)
        {
            for (var i = 0; i < 100; i++)
                writer.WriteLine($"[{DateTime.Now.ToUniversalTime()} : {threadName}]: {Guid.NewGuid()}\r\n");
        }
    }
}
