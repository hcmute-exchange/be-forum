using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Messages.CreateMessage;

public sealed class CreateMessageHandler : ICommandHandler<CreateMessageCommand, Result<Message>>
{
    private readonly IAppDbContext dbContext;
    public CreateMessageHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Message>> ExecuteAsync(CreateMessageCommand command, CancellationToken ct)
    {
        var any = await dbContext.Users.AnyAsync(x => x.Id == command.UserId, cancellationToken: ct)
            .ConfigureAwait(false);
        if (!any)
        {
            return Result.Fail("Use does not exist")
               .WithName(nameof(command.UserId))
               .WithCode("invalid_user")
               .WithStatus(HttpStatusCode.Unauthorized);
        }
        var user = new User
        {
            Id = command.UserId
        };
        var message = command.ToMessage(user);
        dbContext.Attach(user);
        dbContext.Add(message);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return message;
    }
}