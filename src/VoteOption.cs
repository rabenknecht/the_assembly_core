namespace TheAssembly.Core;

public class VoteOption
{
    public string Name { get; }


    private VoteOption(string name)
    {
        Name = name;
    }


    public static VoteOption? FromEncodedString(string s)
    {
        if (!Util.IsNameLegal(s)) return null;
        return new VoteOption(s);
    }

    public string ToEncodedString()
    {
        return Name;
    }
}
