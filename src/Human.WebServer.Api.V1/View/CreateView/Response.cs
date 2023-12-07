namespace Human.WebServer.Api.V1.Views.CreateView;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class ViewResponse
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class ResponseMapper
{
    public static partial ViewResponse ToResponse(this View View);
}