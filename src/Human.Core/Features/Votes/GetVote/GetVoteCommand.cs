using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Votes.GetVote;

public class GetVoteCommand : ICommand<Result<Vote>>
{
    public Guid? MessageId { get; set; }
    public Guid? UserId { get; set; }
}

[Mapper]
internal static partial class GetVoteCommandMapper
{
    public static partial Vote ToVote(this GetVoteCommand command);
}