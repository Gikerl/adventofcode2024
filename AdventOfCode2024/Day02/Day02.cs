using System.Reflection;

namespace AdventOfCode2024.Day01;

public class Day02
{
    public void Run(bool silent)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Day02/Input.txt");
        var lines = File.ReadAllLines(path);

        var safe = 0;
        foreach (var line in lines)
        {
            var values = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            safe += IsSafe(values);
        }

        if (!silent)
            Console.WriteLine(safe);
    }

    private static int IsSafe(int[] values, int index = 0, bool? isAscending = null, bool isTolerant = true)
    {
        if (index + 1 >= values.Length)
            return 1;

        var left = values[index];
        var right = values[index + 1];


        if (left == right)
        {
            if (!isTolerant)
                return 0;
            return IsSafe(CopyWithout(values, index), index, null, false);
        }

        if (Math.Abs(left - right) > 3)
        {
            return CheckTolerance(values, isTolerant);
        }

        if (left < right)
        {
            isAscending ??= true;
            if (isAscending.Value)
                return IsSafe(values, index + 1, isAscending, isTolerant);
            return CheckTolerance(values, isTolerant);
        }

        isAscending ??= false;
        if (!isAscending.Value)
            return IsSafe(values, index + 1, isAscending, isTolerant);
        return CheckTolerance(values, isTolerant);
    }

    private static int CheckTolerance(int[] values, bool isTolerant)
    {
        if (!isTolerant)
            return 0;
        for (var i = 0; i < values.Length; i++)
        {
            if (IsSafe(CopyWithout(values, i), 0, null, false) == 1)
                return 1;
        }
        return 0;
    }

    private static T[] CopyWithout<T>(T[] array, int index)
    {
        var newSpan = new T[array.Length - 1];
        var newSpanIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i == index)
                continue;
            newSpan[newSpanIndex] = array[i];
            newSpanIndex++;
        }

        return newSpan;
    }

    // ReSharper disable once UnusedMember.Local
    private static int IsSafePart1(int[] values)
    {
        bool? isAscending = null;

        for (var index = 0; index < values.Length; index++)
        {
            if (index == values.Length - 1)
                break;

            var left = values[index];
            var right = values[index + 1];

            if (Math.Abs(left - right) > 3)
                return 0;

            if (left == right)
                return 0;

            if (left < right)
            {
                isAscending ??= true;
                if (isAscending.Value)
                    continue;
                return 0;
            }

            isAscending ??= false;
            if (!isAscending.Value)
                continue;
            return 0;
        }

        return 1;
    }
}