using FastEndpoints;
using Human.Core.Features.Messages.GetMessages;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Messages.GetMessages;

internal sealed class GetMessagesRequest
{

}
internal sealed class Validator : Validator<GetMessagesRequest>
{
    // public Validator()
    // {
    //     // RuleFor(x => x.Id)
    //     //     .NotNull();
    // }
}


[Mapper]
internal static partial class GetMessagesRequestMapper
{
    public static partial GetMessagesCommand ToCommand(this GetMessagesRequest request);

}