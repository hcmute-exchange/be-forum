using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace Human.Domain.Models;
public record class View : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public Post Post { get; set; } = null!;
}
