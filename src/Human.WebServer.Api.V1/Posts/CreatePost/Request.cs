using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Messages.CreateMessage;
using Human.Core.Features.Posts.CreatePost;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Posts.CreatePost;

internal sealed class Request
{
    public string? Subject { get; set; }
    public CreateMessageCommand? InitialMessage { get; set; }
    public Guid[]? TagIds { get; set; }

}
internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Subject)
            .NotNull();
        RuleFor(x => x.InitialMessage)
            .NotNull();
        RuleFor(x => x.TagIds)
            .NotNull();

    }
}


[Mapper]
internal static partial class RequestMapper
{
    public static partial CreatePostCommand ToCommand(this Request request);

}