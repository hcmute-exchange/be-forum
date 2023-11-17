namespace Human.WebServer.Api.V1.Tags.GetTags;

using Human.Domain.Models;
using NodaTime;
using Riok.Mapperly.Abstractions;
public class GetTagsResponse
{
    public Guid Id { get; set; }
    public Instant CreatedTime { get; set; }
    public Instant UpdatedTime { get; set; }
    public string Name { get; set; } = null!;
}

[Mapper]
internal static partial class ResponseMapper
{
    public static partial GetTagsResponse[] ToResponse(this Tag[] tag);
}