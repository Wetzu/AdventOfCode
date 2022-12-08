using _7._12;

var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\input.txt";

var lines = new List<string>();
using var reader = new StreamReader(path);

while (!reader.EndOfStream)
{
    lines.Add(reader.ReadLine());
}

var tree = new Tree();

var currentNode = tree.Root;

for (int i = 0; i < lines.Count; i++)
{
    var line = lines[i];

    if (line.StartsWith('$'))
    {
        var commandArgs = line[2..].Split(' ');

        switch (commandArgs[0])
        {
            case "cd":
                var pathFragment = commandArgs[1];
                if (pathFragment == "..")
                {
                    currentNode = currentNode.Parent;
                }
                else if(pathFragment == "/")
                {
                    currentNode = tree.Root;
                }
                else
                {
                    if (currentNode.Children.Any(x => x.Name == pathFragment))
                    {
                        currentNode = currentNode.Children.First(x => x.Name == pathFragment);
                    }
                    else
                    {
                        currentNode.Children.Add(new Node(currentNode, pathFragment));
                        currentNode = currentNode.Children.First(x => x.Name == pathFragment);
                    }
                }
                break;
            case "ls":
                line = lines[++i];
                while (!line.StartsWith('$'))
                {
                    var fields = line.Split(' ');
                    if (fields[0] == "dir")
                    {
                        if (currentNode.Children.All(x => x.Name != fields[1]))
                        {
                            currentNode.Children.Add(new Node(currentNode, fields[1]));
                        }
                    }
                    else
                    {
                        if (currentNode.Children.All(x => x.Name != fields[1]))
                        {
                            currentNode.Children.Add(new Node(currentNode, fields[1], long.Parse(fields[0])));
                        }
                    }

                    if (i < lines.Count - 1)
                    {
                        line = lines[i++];
                    }
                    else
                    {
                        break;
                    }
                    
                }

                break;
        }
    }
}

long CalculateSize(Node node)
{
    if (node.Size == 0)
    {
        foreach (var child in node.Children)
        {
            node.Size += CalculateSize(child);
        }
    }
    return node.Size;
}

_ = CalculateSize(tree.Root);

void PrintTree(Node node, string indent = "")
{
    Console.WriteLine($"{indent, -25} | {node.Name, -15} | {node.Size, -9}");
    indent += "-";
    foreach (var child in node.Children)
    {
        PrintTree(child, indent);
    }
    Console.WriteLine("");
}

PrintTree(tree.Root);

var threshold = 100000;
long total = 0;

void CalculateDeletion(Node node)
{
    if (node.Size <= threshold)
    {
        total += node.Size;
    }
    foreach (var child in node.Children)
    {
        CalculateDeletion(child);
    }
}

CalculateDeletion(tree.Root);

Console.WriteLine($"Deleting a total of {total, 12} bytes");