using NodaTime;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Posts.NewestPosts;

using Human.Domain.Models;
using NodaTime;

public record class Vote : IAggregationRoot
{
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public int Weight { get; set; }
    public User User { get; set; } = null!;
}
public record class View : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
}
public record class MessageDTO : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Body { get; set; } = null!;
    public User User { get; set; } = null!;
    public ICollection<Vote> Votes { get; set; } = null!;

}

public class NewestPostsResponse
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Subject { get; set; } = null!;
    public MessageDTO InitialMessage { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public ICollection<View> Views { get; set; } = null!;
}



[Mapper]
internal static partial class NewestPostsResponseMapper
{
    public static partial NewestPostsResponse[] ToResponse(this Post[] result);
}