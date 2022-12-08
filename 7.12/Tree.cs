namespace _7._12;

public class Tree
{
    public Node Root { get; set; }

    public Tree()
    {
        Root = new Node();
    }
}

public class Node
{
    public Node Parent { get; set; }

    public List<Node> Children { get; set; }

    public bool IsRoot { get; set; } = false;

    public string Name { get; set; }

    public string Path { get; set; }

    public long Size { get; set; }

    public Node(Node parent, string name, long size)
    {
        Parent = parent;
        Name = name;
        Path = parent.Path + "/" + name;
        Children = new List<Node>();
        Size = size;
    }

    public Node(Node parent, string name)
    {
        Parent = parent;
        Name = name;
        Path = parent.Path + "/" + name;
        Children = new List<Node>();
        Size = 0;
    }

    internal Node()
    {
        Parent = this;
        IsRoot = true;
        Name = "/";
        Size = 0;
        Children = new List<Node>();
    }
}