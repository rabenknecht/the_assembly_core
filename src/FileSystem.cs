namespace TheAssembly.Core;

/// <summary>
/// The file system stores Groups, their Entries and UserVotes. Changes in TargetPath may lead to exceptions and unpredictable behaviour.
/// </summary>
public class FileSystem
{
    /// <param name="targetPath">The path to the directory where this FileSystem will store all data.</param>
    /// <returns>Null if the path is not a directory, does not exist,
    /// or contains a file/directory structure it cannot parse (i.e. someome manually modified the directory outside this class).</returns>
    public static FileSystem? OnPath(string targetPath)
    {
        if (!Directory.Exists(targetPath)) return null;

        var metadataPath = GetMetadataPath(targetPath);        
        if (!File.Exists(metadataPath)) return null;

        var metadata = File.ReadAllText(metadataPath).Split("\n");
        var groupIds = metadata.Select(long.Parse).ToList();
        return new FileSystem(targetPath, groupIds);
    }


    public string TargetPath { get; }

    public IEnumerable<long> GroupIds => _groupIds;

    /// <returns>Null if the group id does not exist.</returns>
    public Group? TryLoadGroup(long id)
    {
        if (!_groupIds.Contains(id)) return null;

        var groupPath = Path.Combine(TargetPath, id.ToString());

        if (!Directory.Exists(groupPath)) throw new Exception("Breaking outside modification!");

        return new Group(id, groupPath);
    }

    public void AddGroup()
    {
        
    }


    private readonly List<long> _groupIds;

    private FileSystem(string path, List<long> groupIds)
    {
        TargetPath = path;
        _groupIds = groupIds;
    }

    private string MetadataPath => GetMetadataPath(TargetPath);

    private static string GetMetadataPath(string basePath) => Path.Combine(basePath, "metadata");
}
