using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Messages.GetMessages;

public class GetMessagesCommand : ICommand<Result<Message[]>>
{

}
[Mapper]
internal static partial class GetMessagesCommandMapper
{
    public static partial Message ToMessage(this GetMessagesCommand command);
}