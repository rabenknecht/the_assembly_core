using System;

public record class EntryRecord
(
    string? question,
    DateTimeOffset startsWhen,
    VoteOptionRecord[]? voteOptions
);