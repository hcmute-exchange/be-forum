using NodaTime;

namespace Human.Domain.Models;

public record class Message : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Body { get; set; } = null!;
    public Post? Post { get; set; } = null!;
    public User User { get; set; } = null!;

}
