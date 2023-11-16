namespace Human.Core.Features.Messages.CreateMessage;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class CreateMessageResult
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class CreateMessageResultMapper
{
    public static partial CreateMessageResult ToResult(this Message message);
}