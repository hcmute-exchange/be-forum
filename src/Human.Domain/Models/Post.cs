using NodaTime;

namespace Human.Domain.Models;
using NpgsqlTypes;

public record class Post : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Subject { get; set; } = null!;
    public Message InitialMessage { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public ICollection<View> Views { get; set; } = null!;
    public NpgsqlTsVector SearchVector { get; set; }

}
