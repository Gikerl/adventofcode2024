using System.Reflection;

namespace AdventOfCode2024.Day01;

public class Day01
{
    public void Run()
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Day01/Input.txt");
        var lines = File.ReadAllLines(path);

        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in lines)
        {
            var split = line.Split(' ')
                .Where(x => x != string.Empty)
                .ToArray();

            left.Add(Convert.ToInt32(split[0]));
            right.Add(Convert.ToInt32(split[1]));
        }

        left.Sort();
        right.Sort();

        var totalDistance = 0;
        for (int i = 0; i < left.Count; i++)
            totalDistance += Math.Abs(left[i] - right[i]);

        Console.WriteLine(totalDistance);

        var total = 0;
        foreach (var number in left)
        {
            var count = right.Count(i => i == number);
            total += number * count;
        }
        Console.WriteLine(total);
    }
}