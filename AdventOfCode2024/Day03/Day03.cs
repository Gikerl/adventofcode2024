using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day01;

public class Day03
{
    public void Run(bool silent)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Day03/Input.txt");
        var lines = File.ReadLines(path);

        var result = PartTwo(lines);

        if (!silent)
            Console.WriteLine(result);
    }

    private static int PartTwo(IEnumerable<string> lines)
    {
        var regex = new Regex("mul\\((\\d*),(\\d*)\\)|don't|do");

        var result = 0;
        bool enabled = true;
        foreach (var line in lines)
        {
            MatchCollection matches = regex.Matches(line);
            for (var index = 0; index < matches.Count; index++)
            {
                Match match = matches[index];
                if (match.Value == "don't")
                {
                    enabled = false;
                    continue;
                }

                if (match.Value == "do")
                {
                    enabled = true;
                    continue;
                }
                if (!enabled)
                    continue;

                var left = int.Parse(match.Groups[1].Value);
                var right = int.Parse(match.Groups[2].Value);
                result += left * right;
            }
        }

        return result;
    }

    // ReSharper disable once UnusedMember.Local
    private static int PartOne(IEnumerable<string> lines)
    {
        var regex = new Regex("mul\\((\\d*),(\\d*)\\)");
        var result = 0;
        foreach (var line in lines)
        {
            var matches = regex.Matches(line);
            foreach (Match match in matches)
            {
                var left = int.Parse(match.Groups[1].Value);
                var right = int.Parse(match.Groups[2].Value);
                result += left * right;
            }
        }

        return result;
    }
}