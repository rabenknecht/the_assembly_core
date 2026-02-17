namespace TheAssembly.Core;

public class User
{
    public string Name { get; private set; }


    private User(string name)
    {
        Name = name;
    }


    public static User? FromEncodedString(string s)
    {
        if (!Util.IsNameLegal(s)) return null;
        return new User(s);
    }

    public string ToEncodedString()
    {
        return Name;
    }
}
