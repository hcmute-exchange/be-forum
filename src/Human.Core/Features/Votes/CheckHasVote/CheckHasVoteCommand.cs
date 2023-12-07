using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Votes.CheckHasVote;

public class CheckHasVoteCommand : ICommand<Result<Vote>>
{
    public Guid? MessageId { get; set; }
    public Guid? UserId { get; set; }
}

[Mapper]
internal static partial class CheckHasVoteCommandMapper
{
    public static partial Vote ToVote(this CheckHasVoteCommand command);
}