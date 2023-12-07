using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Votes.PutVotes;

public class PutVoteCommand : ICommand<Result<Vote>>
{
    public Guid? MessageId { get; set; }
    public Guid? UserId { get; set; }
}

[Mapper]
internal static partial class PutVoteCommandMapper
{
    public static partial Vote ToVote(this PutVoteCommand command);
}