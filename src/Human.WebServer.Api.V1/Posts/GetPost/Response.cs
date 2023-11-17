using Human.Domain.Models;
using NodaTime;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Posts.GetPost;
public class GetPostResponse
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Subject { get; set; } = null!;
    public Message InitialMessage { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
}



[Mapper]
internal static partial class GetPostResponseMapper
{
    public static partial GetPostResponse ToResponse(this Post result);
}