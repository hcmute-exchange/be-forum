using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Messages.GetMessage;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Messages.GetMessage;

internal sealed class GetMessageRequest
{
    public Guid? Id { get; set; }

}
internal sealed class Validator : Validator<GetMessageRequest>
{
    public Validator()
    {
        RuleFor(x => x.Id)
            .NotNull();
    }
}


[Mapper]
internal static partial class RequestMapper
{
    public static partial GetMessageCommand ToCommand(this GetMessageRequest request);

}