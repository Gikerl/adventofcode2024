using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode2024.Day01;

public class Day04
{
    // Average execution time over 10000 runs: 10.820 ms
    public void Run(bool silent)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Day04/Input.txt");
        var allLines = new List<char[]>();
        foreach (var line in File.ReadLines(path))
            allLines.Add(line.ToCharArray());

        // Part 1
        var count = 0;
        var windowSize = 4;
        for (int y = 0; y < allLines.Count; y++)
        {
            for (int x = 0; x < allLines[0].Length; x++)
            {
                foreach (char[] window in CreateWindows(windowSize, x, y, allLines))
                {
                    count += CountXmas(window);
                }
            }
        }
        if (!silent)
            Console.WriteLine($"Part 1: {count}");

        count = 0;
        windowSize = 3;
        for (int y = 0; y < allLines.Count; y++)
        {
            for (int x = 0; x < allLines[0].Length; x++)
            {
                var found = 0;
                foreach (char[] window in CreateWindows(windowSize, x, y, allLines, true))
                {
                    found += CountXMas(window);
                }

                if (found == 2) 
                    count++;
            }
        }
        if (!silent)
            Console.WriteLine($"Part 2: {count}");
    }

    private IEnumerable<char[]> CreateWindows(int windowSize, int x, int y, List<char[]> allLines, bool onlyDiagonal = false)
    {
        var window = new char[windowSize];
        var canVaryX = x <= allLines[0].Length - windowSize;
        var canVaryY = y <= allLines.Count - windowSize;

        if (canVaryX && !onlyDiagonal)
        {
            for (int i = 0; i < windowSize; i++)
                window[i] = allLines[y][x + i];
            yield return window;
        }

        if (canVaryY && !onlyDiagonal)
        {
            for (int i = 0; i < windowSize; i++)
                window[i] = allLines[y + i][x];
            yield return window;
        }

        if (canVaryX && canVaryY)
        {
            for (int i = 0; i < windowSize; i++)
                window[i] = allLines[y + i][x + i];
            yield return window;

            for (int i = 0; i < windowSize; i++)
                window[i] = allLines[y + windowSize - 1 - i][x + i];
            yield return window;
        }
    }


    private char[] Xmas = new[] { 'X', 'M', 'A', 'S' };
    private char[] Samx = new[] { 'S', 'A', 'M', 'X' };
    public int CountXmas(char[] input)
    {
        if (input.SequenceEqual(Xmas) || input.SequenceEqual(Samx))
            return 1;
        return 0;
    }

    private char[] Mas = new[] { 'M', 'A', 'S' };
    private char[] Sam = new[] { 'S', 'A', 'M' };
    private int CountXMas(char[] input)
    {
        if (input.SequenceEqual(Mas) || input.SequenceEqual(Sam))
            return 1;
        return 0;
    }
}