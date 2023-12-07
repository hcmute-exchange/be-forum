namespace Human.Core.Features.Messages.DeleteMessage;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class DeleteMessageResult
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class DeleteMessageResultMapper
{
    public static partial DeleteMessageResult ToResult(this Message message);
}