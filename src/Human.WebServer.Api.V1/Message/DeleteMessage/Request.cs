using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Messages.DeleteMessage;
namespace Human.WebServer.Api.V1.Messages.DeleteMessage;

using System.Security.Claims;
using Riok.Mapperly.Abstractions;
internal sealed class Request
{
    public Guid Id { get; set; }


    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}

[Mapper]
internal static partial class RequestMapper
{
    public static partial DeleteMessageCommand ToCommand(this Request request);

}