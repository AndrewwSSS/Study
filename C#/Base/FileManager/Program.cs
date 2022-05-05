using System;
using System.Diagnostics;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(@"C:\");
            Stopwatch stopwatch = Stopwatch.StartNew();

            manager.ReadChildren();

            Console.WriteLine($"First - {stopwatch.Elapsed.TotalSeconds}");
            stopwatch.Stop();

            stopwatch = Stopwatch.StartNew();

            manager.ReadChildren();

            Console.WriteLine($"Second - {stopwatch.Elapsed.TotalSeconds}");
            stopwatch.Stop();

            Console.ReadKey();

            manager.SaveToFile(@".\save.xml");
        }
    }
}
