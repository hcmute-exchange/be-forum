namespace Human.Core.Features.Posts.CreatePost;

using Human.Core.Features.Messages.CreateMessage;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class CreatePostResult
{
    public required Guid Id { get; set; }
    public required CreateMessageCommand? InitialMessage { get; set; } = null!;
}



[Mapper]
internal static partial class CreatePostResultMapper
{
    public static partial CreatePostResult ToResult(this Post message);
}