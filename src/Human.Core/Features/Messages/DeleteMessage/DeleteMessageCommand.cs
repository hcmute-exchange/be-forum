using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Messages.DeleteMessage;

public class DeleteMessageCommand : ICommand<Result<Message>>
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
}

[Mapper]
internal static partial class DeleteMessageCommandMapper
{

}