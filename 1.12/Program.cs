// See https://aka.ms/new-console-template for more information
using _1._12;

var elfs = Util.LoadElfs(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\input.txt");

elfs = elfs.OrderByDescending(x => x.TotalCalories);

foreach (var elf in elfs)
{
    Console.WriteLine($"Elf Nr {elf.Number, 3} carrying {elf.TotalCalories, 6} Calories");
}

Console.WriteLine(new string('-', 15));

var elfsToAdd = 3;
var result = elfs.Take(elfsToAdd).Sum(x => x.TotalCalories);
Console.WriteLine($"Top {elfsToAdd} carrying {result}");