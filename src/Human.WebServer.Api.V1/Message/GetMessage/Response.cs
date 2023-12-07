using Human.Domain.Models;
using NodaTime;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Messages.GetMessage;



public record class User : IAggregationRoot
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Email { get; set; } = null!;
}

public class GetMessageResponse
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Body { get; set; } = null!;
    public User User { get; set; } = null!;
}



[Mapper]
internal static partial class GetMessageResponseMapper
{
    public static partial GetMessageResponse ToResponse(this Message result);
}