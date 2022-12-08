using System.Text;
using System.Text.RegularExpressions;

namespace _5._12;

public static class Util
{
    public static Dictionary<int, Stack<char>> LoadStacks(string path)
    {
        using var reader = new StreamReader(path);

        bool foundNumbersLine = false;
        var stackLines = new List<string>();
        var stacks = new Dictionary<int, Stack<char>>();

        while (!foundNumbersLine)
        {
            var line = reader.ReadLine();
            if (line.Contains('1'))
            {
                foundNumbersLine = true;
                var numbersString = line.Split(' ');
                var numbers = new List<int>();
                foreach (var x in numbersString)
                {
                    if (x != "")
                    {
                        numbers.Add(int.Parse(x));
                    }
                }
                foreach (var number in numbers)
                {
                    stacks.Add(number, new Stack<char>());
                }

                stackLines.Reverse();

                foreach (var stackLine in stackLines)
                {
                    var chars = stackLine.ToCharArray();
                    var stackNr = 1;
                    for (int i = 0; i < chars.Length; i += 4)
                    {
                        char currentChar = chars[i + 1];
                        if (currentChar != ' ')
                        {
                            stacks[stackNr].Push(currentChar);
                        }

                        stackNr++;
                    }
                }

            }
            else
            {
                stackLines.Add(line);
            }
        }

        return stacks;
    }

    public static Dictionary<int, Stack<char>> CloneDictionary(Dictionary<int, Stack<char>> source)
    {
        var copy = new Dictionary<int, Stack<char>>();
        foreach (var (key, stack) in source)
        {
            copy.Add(key, new Stack<char>(new Stack<char>(stack.ToArray())));
        }
        return copy;
    }

    public static void PrintStacks(Dictionary<int, Stack<char>> stacks)
    {
        var stacksForPrinting = CloneDictionary(stacks);

        int stackHeight = stacksForPrinting.Max(x => x.Value.Count);

        var printLines = new List<string>();

        for (int i = 1; i <= stackHeight; i++)
        {
            var builder = new StringBuilder();

            foreach (var (key, stack) in stacksForPrinting)
            {
                if (stack.TryPop(out var val))
                {
                    builder.Append($"[{val}] ");
                }
                else
                {
                    builder.Append("    ");
                }

            }

            printLines.Add(builder.ToString());
        }

        printLines.Reverse();

        foreach (var printLine in printLines)
        {
            Console.WriteLine(printLine);
        }

        var keys = stacksForPrinting.Select(x => x.Key);
        var numbersBuilder = new StringBuilder();

        foreach (var key in keys)
        {
            numbersBuilder.Append($" {key}  ");
        }

        Console.WriteLine(numbersBuilder.ToString());
    }

    public static IEnumerable<(int Source, int Target, int Count)> ReadInstructions(string path)
    {
        var result = new List<(int Source, int Target, int Count)>();

        using var reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line.Contains("move"))
            {
                var pattern = @"\d+";
                var matches = Regex.Matches(line, pattern);
                if (matches.Count == 3)
                {
                    var values = matches.Select(x => x.Value).ToArray();

                    int count = int.Parse(values[0]), source = int.Parse(values[1]), target = int.Parse(values[2]);

                    Console.WriteLine($"Parsed Instruction: Move {count} from {source} to {target}");
                    result.Add((source, target, count));
                }
            }
        }

        return result;
    }
}