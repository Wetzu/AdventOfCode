var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\input.txt";

using var reader = new StreamReader(path);

ReadOnlySpan<char> chars = reader.ReadToEnd();

var scope = 14;

for (int i = 0; i < chars.Length - 3; i++)
{
    var currentScope = chars.Slice(i, scope);
    var characters = new List<char>();

    for (int j = 0; j < scope; j++)
    {
        if (!characters.Contains(currentScope[j]))
        {
            characters.Add(currentScope[j]);
        }
    }

    if (characters.Count == scope)
    {
        Console.WriteLine($"Sequence found starting at {i+1}, ending at {i+scope}. Sequence is \"{currentScope}\" ");
        break;
    }
    else
    {
        characters.Clear();
    }
}