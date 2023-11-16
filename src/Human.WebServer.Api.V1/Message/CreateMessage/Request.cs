using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Messages.CreateMessage;
namespace Human.WebServer.Api.V1.Messages.CreateMessage;

using Riok.Mapperly.Abstractions;
internal sealed class Request
{
    public string? Body { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ThreadId { get; set; }
}

internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Body)
            .NotEmpty();
        RuleFor(x => x.UserId)
            .NotNull();
        // RuleFor(x => x.ThreadId)
        //     .NotNull();
    }
}

[Mapper]
internal static partial class RequestMapper
{
    public static partial CreateMessageCommand ToCommand(this Request request);

}