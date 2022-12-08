using System.Text;
using _5._12;

var path = @"C:\Users\jessig\Desktop\AdventOfCode\5.12\input.txt";

var stacks = Util.LoadStacks(path);
Console.WriteLine("Initial State");
Console.WriteLine("");
Util.PrintStacks(stacks);
Console.WriteLine(new string('-', 36));

var instructions = Util.ReadInstructions(path);

//Part1
//foreach (var (source, target, count) in instructions)
//{
//    for(int i = 0; i < count; i++)
//    {
//        stacks[target].Push(stacks[source].Pop());
//    }
//}

//Part2
foreach (var (source, target, count) in instructions)
{
    var buffer = new Stack<char>();

    for (int i = 0; i < count; i++)
    {
        buffer.Push(stacks[source].Pop());
    }

    for (int i = 0; i < count; i++)
    {
        stacks[target].Push(buffer.Pop());
    }
}

Util.PrintStacks(stacks);