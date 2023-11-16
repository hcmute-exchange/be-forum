using Riok.Mapperly.Abstractions;
using Human.Domain.Models;

namespace Human.WebServer.Api.V1.Messages.CreateMessage;

public class MessageResponse
{
    public required Guid Id { get; set; }
}


[Mapper]
internal static partial class ResponseMapper
{
    public static partial MessageResponse ToResponse(this Message result);
}