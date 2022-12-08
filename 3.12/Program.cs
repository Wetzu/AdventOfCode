using System;
using System.IO;

var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\input.txt";

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
                concat = concat.Concat(lineToParse.Distinct());
            }

            var group = concat.GroupBy(e => e);
            var doubles = group.Where(e => e.Count() == lines.Count).Select(e => e.Key);
            sum += GetPrio(doubles.FirstOrDefault());
            lines.Clear();
        }
    }
}

Console.WriteLine(sum);