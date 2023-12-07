using Riok.Mapperly.Abstractions;
using Human.Domain.Models;

namespace Human.WebServer.Api.V1.Messages.DeleteMessage;

public class DeleteMessageResponse
{
}


[Mapper]
internal static partial class ResponseMapper
{
    public static partial DeleteMessageResponse ToResponse(this Message result);
}