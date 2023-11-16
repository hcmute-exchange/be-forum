namespace Human.Core.Features.Posts.CreatePost;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class CreatePostResult
{
    public required Guid Id { get; set; }
}



[Mapper]
internal static partial class CreateMessageResultMapper
{
    public static partial CreatePostResult ToResult(this Post message);
}