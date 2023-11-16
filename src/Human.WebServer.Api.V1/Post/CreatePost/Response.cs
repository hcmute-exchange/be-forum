using Human.Core.Features.Posts.CreatePost;
using Riok.Mapperly.Abstractions;
namespace Human.WebServer.Api.V1.Post.CreatePost;
public class PostResponse
{
    public required Guid Id { get; set; }
}



[Mapper]
internal static partial class PostResponseMapper
{
    public static partial PostResponse ToResponse(this CreatePostResult result);
}