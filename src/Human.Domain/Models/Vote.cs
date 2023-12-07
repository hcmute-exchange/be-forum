using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace Human.Domain.Models;
public record class Vote : IAggregationRoot
{
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public int Weight { get; set; }
    public User User { get; set; } = null!;
    public Message Message { get; set; } = null!;
}
