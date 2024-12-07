using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode2024.Day01;

public class Day07
{
    public void Run(bool silent)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Day07/Input.txt");

        long count = 0;
        foreach (var line in File.ReadLines(path))
        {
            count += AnalyzePart2(line);
        }

        if (!silent)
            Console.WriteLine(count);
    }

    private readonly char[] _separators = [':', ' '];
    private long AnalyzePart1(string line)
    {
        var split = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
        var numbers = new long[split.Length];
        for (int i = 0; i < split.Length; i++)
            numbers[i] = long.Parse(split[i]);


        var result = numbers[0];
        int maxOperator = (int)Math.Pow(2, numbers.Length - 2);
        for (int operators = 0; operators <= maxOperator; operators++)
        {
            var binaryOperation = new BitArray(new[] { operators });
            var number = numbers[1];
            for (int i = 2; i < numbers.Length; i++)
            {
                if (binaryOperation[i - 2] == false)
                    number += numbers[i];
                else
                    number *= numbers[i];

                if (number > result)
                    break;
            }
            if (result == number)
                return result;
        }

        return 0;
    }

    private long AnalyzePart2(string line)
    {
        var split = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
        var numbers = new long[split.Length];
        for (int i = 0; i < split.Length; i++)
            numbers[i] = long.Parse(split[i]);


        var result = numbers[0];
        int maxOperator = (int)Math.Pow(2, (numbers.Length - 2) * 2) - 1;
        for (int operators = 0; operators <= maxOperator; operators++)
        {
            var binaryOperation = new BitArray(new[] { operators });
            int binaryIndex = 0;
            var number = numbers[1];
            for (int i = 2; i < numbers.Length; i++)
            {
                var bin0 = binaryOperation[binaryIndex++];
                var bin1 = binaryOperation[binaryIndex++];

                if (bin0 && bin1)
                    continue;

                if (bin0)
                    number *= numbers[i];
                else if (bin1)
                    number = long.Parse(string.Concat(number, numbers[i]));
                else
                    number += numbers[i];

                if (number > result)
                    break;
            }
            if (result == number)
                return result;
        }

        return 0;
    }
}