using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Messages.GetMessagesPost;

public class GetMessagesPostCommand : ICommand<Result<Message[]>>
{
    public required Guid PostId { get; set; }
}
[Mapper]
internal static partial class GetMessagesCommandMapper
{
    public static partial Message ToMessage(this GetMessagesPostCommand command);
}