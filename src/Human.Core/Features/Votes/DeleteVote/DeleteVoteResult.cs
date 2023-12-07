namespace Human.Core.Features.Votes.DeleteVotes;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class DeleteVoteResult
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class DeleteVoteResultMapper
{
}