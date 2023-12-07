namespace Human.Core.Features.Votes.PutVotes;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class PutVoteResult
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class PutVoteResultMapper
{
}