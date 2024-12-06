using AdventOfCode2024.Day01;
using System.Diagnostics;
using System.Globalization;

namespace AdventOfCode2024
{
    internal class Program
    {
        private static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            var task = new Day04();
            task.Run(false);

            //void BenchmarkAction()
            //{
            //    var benchMarkTask = new Day04();
            //    benchMarkTask.Run(true);
            //}
            //Benchmark(BenchmarkAction, 10000);
        }

        private static void Benchmark(Action act, int iterations)
        {
            GC.Collect();
            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < iterations; i++)
                act.Invoke();
            stopwatch.Stop();
            Console.WriteLine($"Average execution time over {iterations} runs: {(double)stopwatch.ElapsedMilliseconds / iterations:F3} ms: ");
        }
    }
}
