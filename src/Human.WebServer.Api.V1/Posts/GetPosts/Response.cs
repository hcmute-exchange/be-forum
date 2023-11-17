using Human.Domain.Models;
using NodaTime;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Posts.GetPosts;
public class GetPostsResponse
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Subject { get; set; } = null!;
    public Message InitialMessage { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
}



[Mapper]
internal static partial class GetPostsResponseMapper
{
    public static partial GetPostsResponse[] ToResponse(this Post[] result);
}