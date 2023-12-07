using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Messages.CreateMessage;

public class CreateMessageCommand : ICommand<Result<Message>>
{
    public required string Body { get; set; }
    public required Guid UserId { get; set; }
    public required Guid PostId { get; set; }
}

[Mapper]
internal static partial class CreateMessageCommandMapper
{
    public static partial Message ToMessage(this CreateMessageCommand command);
    public static Message ToMessage(this CreateMessageCommand command, User user)
    {
        return command.ToMessage() with { User = user };
    }
}