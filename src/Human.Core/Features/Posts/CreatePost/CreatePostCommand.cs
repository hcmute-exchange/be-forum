using FastEndpoints;
using FluentResults;
using Human.Core.Features.Messages.CreateMessage;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Posts.CreatePost;

public class CreatePostCommand : ICommand<Result<CreatePostResult>>
{
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required Tag[] Tags { get; set; }
    public required Guid UserId { get; set; }

}

[Mapper]
internal static partial class CreateThreadCommandMapper
{
    public static partial Post ToPost(this CreatePostCommand command);
    public static Post ToPost(this CreatePostCommand command, CreateMessageCommand messageCommand)
    {
        return command.ToPost() with { InitialMessage = messageCommand.ToMessage() };
    }
}