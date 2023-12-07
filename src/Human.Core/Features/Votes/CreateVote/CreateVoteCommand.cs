using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Votes.CreateVotes;

public class CreateVoteCommand : ICommand<Result<Vote>>
{
    public Guid? MessageId { get; set; }
    public Guid? UserId { get; set; }
}

[Mapper]
internal static partial class CreateVoteCommandMapper
{
    public static partial Vote ToVote(this CreateVoteCommand command);
}