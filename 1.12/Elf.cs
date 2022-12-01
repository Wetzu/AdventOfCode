namespace _1._12;

public class Elf
{
    public int[] Calories { get; set; }

    public int Number { get; set; }

    public Elf(int[] values, int number)
    {
        Calories = values;
        Number = number;
    }

    public int TotalCalories => Calories.Aggregate<int>((total, next) => total += next);
}