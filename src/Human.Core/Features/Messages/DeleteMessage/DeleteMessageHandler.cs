using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Messages.DeleteMessage;

public sealed class DeleteMessageHandler : ICommandHandler<DeleteMessageCommand, Result<Message>>
{
    private readonly IAppDbContext dbContext;
    public DeleteMessageHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Message>> ExecuteAsync(DeleteMessageCommand command, CancellationToken ct)
    {
        var message = await dbContext.Messages.Where(x => x.Id == command.Id).Include(x => x.User).FirstOrDefaultAsync(ct);
        if (message.User.Id != command.UserId)
        {
            return Result.Fail("User cannot delete message")
              .WithName(nameof(command.Id))
              .WithCode("invalid_user")
              .WithStatus(HttpStatusCode.Unauthorized);
        }
        dbContext.Messages.Remove(message);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return Result.Ok();
    }

}