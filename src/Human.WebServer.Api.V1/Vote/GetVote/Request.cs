using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Votes.GetVote;
namespace Human.WebServer.Api.V1.Votes.GetVotes;

using System.Security.Claims;
using Riok.Mapperly.Abstractions;
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
internal static partial class RequestMapper
{
    public static partial GetVoteCommand ToCommand(this Request request);

}