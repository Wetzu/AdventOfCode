
var path = @"C:\Users\jessig\Desktop\AdventOfCode\4.12\input.txt";
using var reader = new StreamReader(path);

var pairs = new List<((int Start, int End), (int Start, int End))>();

var line = "";

while (!reader.EndOfStream)
{
    line = reader.ReadLine();
    var parts = line.Split(',');
    var pair1 = parts[0].Split('-');
    var pair2 = parts[1].Split('-');

    pairs.Add(((int.Parse(pair1[0]), int.Parse(pair1[1])), (int.Parse(pair2[0]), int.Parse(pair2[1]))));
}

var count = 0;

//Part 1
//foreach (var pair in pairs)
//{
//    var elf1 = pair.Item1;
//    var elf2 = pair.Item2;
//    if ((elf1.Start >= elf2.Start && elf1.End <= elf2.End) || (elf2.Start >= elf1.Start && elf2.End <= elf1.End))
//    {
//        count++;
//    }
//}

//Part 2
foreach (var pair in pairs)
{
    var elf1 = pair.Item1;
    var elf2 = pair.Item2;
    if ((elf1.Start <= elf2.Start && elf2.Start <= elf1.End) || (elf2.Start <= elf1.Start && elf1.Start <= elf2.End))
    {
        count++;
    }
}

Console.WriteLine(count);