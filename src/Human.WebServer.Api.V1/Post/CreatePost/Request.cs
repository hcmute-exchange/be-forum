using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Messages.CreateMessage;
using Human.Core.Features.Posts.CreatePost;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Post.CreatePost;

internal sealed class Request
{
    public string? Subject { get; set; }
    public CreateMessageCommand? InitialMessage { get; set; }
    
}
internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Subject)
            .NotNull();
    }
}


[Mapper]
internal static partial class RequestMapper
{
    public static partial CreatePostCommand ToCommand(this Request request);

}