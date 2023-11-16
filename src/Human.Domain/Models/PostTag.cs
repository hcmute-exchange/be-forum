using NodaTime;

namespace Human.Domain.Models;

public record class PostTag : IAggregationRoot
{
    public Guid Id { get; set; }
    public Post Post { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}