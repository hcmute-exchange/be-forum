using FastEndpoints;
using FluentResults;
using Human.Domain.Models;

namespace Human.Core.Features.Messages.GetMessage;

public class GetMessageCommand : ICommand<Result<Message>>
{
    public required Guid Id { get; set; }
}
