namespace TheAssembly.Core;

public static class Util
{
    public static bool IsNameLegal(string name) 
    {
        return name.Length > 0
            && char.IsLetter(name[0])
            && name.Skip(1).All(c => char.IsLetterOrDigit(c));
    }
}
