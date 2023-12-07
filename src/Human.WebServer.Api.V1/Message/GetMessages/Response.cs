using NodaTime;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Messages.GetMessages;

using Human.Domain.Models;
using NodaTime;

public record class User : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Email { get; set; } = null!;
}

public class GetMessagesResponse
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Body { get; set; } = null!;
    public User User { get; set; } = null!;
}


[Mapper]
internal static partial class GetMessagesResponseMapper
{
    public static partial GetMessagesResponse[] ToResponse(this Message[] messages);
}