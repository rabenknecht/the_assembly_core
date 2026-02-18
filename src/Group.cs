namespace TheAssembly.Core;

public class Group
{
    public long Id { get; }
    public string Name { get; }
    public IEnumerable<long> EntryIds => _entryIds;


    public Entry? GetEntry(long id)
    {
        throw new NotImplementedException();
    }

    // We do not directly encode Groups


    private readonly string _rootPath;
    private readonly List<long> _entryIds;


    internal Group(long id, string rootPath)
    {
        Id = id;
        _rootPath = rootPath;

        var groupMetadataPath = Path.Combine(rootPath, "metadata");
        if (!File.Exists(groupMetadataPath)) throw new Exception("Breaking outside modification!");

        var metadata = File.ReadAllText(groupMetadataPath).Split("\n");
        Name = metadata[0];
        _entryIds = metadata.Skip(1).Select(long.Parse).ToList();
    }
}
