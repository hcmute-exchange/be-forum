using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;
using NpgsqlTypes;

namespace Human.Domain.Models;

public record class Message : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Body { get; set; } = null!;
    public Post Post { get; set; } = null!;
    public User User { get; set; } = null!;
    public ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();
    public NpgsqlTsVector SearchVector { get; set; }
}
