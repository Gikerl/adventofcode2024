using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode2024.Day01;

public class Day00
{
    public void Run(bool silent)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Day00/Input.txt");
        var lines = File.ReadAllLines(path);

        var output = "";
        if (!silent) 
            Console.WriteLine(output);
    }
}