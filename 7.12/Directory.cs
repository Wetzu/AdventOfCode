namespace _7._12;

public class Directory
{
    public string Path { get; set; }

    public string FolderName { get; set; }

    public List<File> Files { get; set; }

    public List<Directory> Folders { get; set; }

    public long Size => Files.Sum(x => x.Size) + Folders.Sum(x => x.Size);

    public Directory(string path)
    {
        Path = path;
        FolderName = Path.Split('/').Last() ?? "/";
    }
}