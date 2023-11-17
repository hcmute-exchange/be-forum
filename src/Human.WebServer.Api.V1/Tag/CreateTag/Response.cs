namespace Human.WebServer.Api.V1.Tags.CreateTag;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class TagResponse
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class ResponseMapper
{
    public static partial TagResponse ToResponse(this Tag tag);
}