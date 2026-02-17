namespace TheAssembly.Core;

public class Entry
{
    public string Question { get; }
    public IEnumerable<UserVote> Votes => _votes;
    private readonly ICollection<UserVote> _votes;

    private const string LINE_DELIMITERS = "\n";


    private Entry(string question, ICollection<UserVote> votes)
    {
        Question = question;
        _votes = votes;
    }


    public static Entry? FromEncodedString(string s)
    {
        var lines = s.Split(LINE_DELIMITERS);
        if (lines.Length == 0) return null;

        var question = lines[0];
        var votes = lines
            .Skip(1)
            .Select(l => UserVote.FromEncodedString(l))
            .ToList();
        if (votes.Any(v => v == null)) return null;

        return new Entry(question, votes!);
    }

    public string ToEncodedString()
    {
        var lines = Votes
            .Select(v => v.ToEncodedString())
            .Prepend(Question);
        return $"{string.Join(LINE_DELIMITERS, lines)}";
    }
}
