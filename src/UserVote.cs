namespace TheAssembly.Core;

public class UserVote
{
    public VoteOption VoteOption { get; }
    public User User { get; }

    private const string ENCODING_DELIMITER = ":";


    private UserVote(User user, VoteOption voteOption)
    {
        User = user;
        VoteOption = voteOption;
    }


    public static UserVote? FromEncodedString(string s)
    {
        var split = s.Split(ENCODING_DELIMITER);
        if (split.Length != 2) return null;

        var user = User.FromEncodedString(split[0]);
        var voteOption = VoteOption.FromEncodedString(split[1]);
        if (user == null || voteOption == null) return null;

        return new UserVote(user, voteOption);
    }


    public string ToEncodedString()
    {
        return $"{User.ToEncodedString()}{ENCODING_DELIMITER}{VoteOption.ToEncodedString()}";
    }
}
