using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Messages.GetMessagesPost;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Messages.GetMessagesPost;

internal sealed class GetMessagesPostRequest
{
    [FromQuery]
    public Guid PostId { get; set; }
}
internal sealed class Validator : Validator<GetMessagesPostRequest>
{
    public Validator()
    {
        RuleFor(x => x.PostId)
            .NotNull();
    }
}


[Mapper]
internal static partial class GetMessagesPostRequestMapper
{
    public static partial GetMessagesPostCommand ToCommand(this GetMessagesPostRequest request);

}