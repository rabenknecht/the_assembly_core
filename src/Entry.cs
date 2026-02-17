namespace TheAssembly.Core;

public class Entry
{
    public string Question => throw new NotImplementedException();
    public IEnumerable<UserVote> Votes => throw new NotImplementedException();


    private Entry() {}


    public static Entry FromEncodedString(string s)
    {
        throw new NotImplementedException();
    }

    public string ToEncodedString()
    {
        throw new NotImplementedException();
    }
}
