using System;
using System.IO;

var path = @"C:\Users\jessig\Desktop\AdventOfCode\3.12\input.txt";

int sum = 0;

int GetPrio(char character)
{
    /*
     * cast a to 97
cast z to 122
cast A to 65
cast Z to 90
     */
    int val = character;
    if (val >= 65 && val <= 90)
    {
        return val - 38;
    }
    return val - 96;
}

if (File.Exists(path))
{
    using var reader = new StreamReader(path);
    string line;
    var lines = new List<string>();
    while ((line = reader.ReadLine()) != null)
    {
        if (lines.Count < 3)
        {
            lines.Add(line);
        }
        else
        {
            IEnumerable<char> concat = new List<char>();
            foreach (var lineToParse in lines)
            {
                var itemsCount = lineToParse.Length / 2;
                var compA = lineToParse.Take(itemsCount);
                var compB = lineToParse.TakeLast(itemsCount);

                var compAChars = compA.Distinct();
                var compBChars = compB.Distinct();

                concat = concat.Concat(compAChars).Concat(compBChars);

            }

            lines.Clear();

            var group = concat.GroupBy(e => e);
            var doubles = group.Where(e => e.Count() > 2);
            sum += GetPrio(doubles.First().Key);
        }
    }
}

Console.WriteLine(sum);