using System.Security.Claims;
using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Votes.CheckHasVote;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Votes.CheckHasVote;

internal sealed class Request
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }
    public Guid MessageId { get; set; }
}


internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.MessageId)
            .NotNull();
        RuleFor(x => x.UserId)
            .NotNull();
    }
}
[Mapper]

internal static partial class CreateVoteCommandMapper
{
    public static partial CheckHasVoteCommand ToCommand(this Request request);
}