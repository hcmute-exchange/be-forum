namespace Human.Core.Features.Votes.CreateVotes;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class CreateVoteResult
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class CreateVoteResultMapper
{
}