using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Votes.DeleteVotes;

public class DeleteVoteCommand : ICommand<Result<Vote>>
{
    public Guid? MessageId { get; set; }
    public Guid? UserId { get; set; }
}

[Mapper]
internal static partial class DeleteVoteCommandMapper
{
    public static partial Vote ToVote(this DeleteVoteCommand command);
}