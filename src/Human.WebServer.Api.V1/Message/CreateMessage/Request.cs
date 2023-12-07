using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Messages.CreateMessage;
namespace Human.WebServer.Api.V1.Messages.CreateMessage;

using System.Security.Claims;
using Riok.Mapperly.Abstractions;
internal sealed class Request
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }
    public string? Body { get; set; }
    public Guid PostId { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Body)
            .NotEmpty();
        RuleFor(x => x.PostId)
            .NotEmpty();
    }
}

[Mapper]
internal static partial class RequestMapper
{
    public static partial CreateMessageCommand ToCommand(this Request request);

}