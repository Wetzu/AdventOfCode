namespace _1._12;

public static class Util
{
    public static IEnumerable<Elf> LoadElfs(string path)
    {
        var result = new List<Elf>();

        if (File.Exists(path))
        {
            using (var reader = new StreamReader(path))
            {
                string line;
                int elfCount = 0;
                List<int> values = new();
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out var value) && value != 0)
                    {
                        values.Add(value);
                    }
                    else
                    {
                        elfCount++;
                        result.Add(new Elf(values.ToArray(), elfCount));
                        values = new();
                    }
                }
            }

        }

        return result;
    }
}