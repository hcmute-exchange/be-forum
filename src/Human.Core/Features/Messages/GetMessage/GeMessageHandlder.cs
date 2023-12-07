
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Messages.GetMessage;

public sealed class GetMessageHandler : ICommandHandler<GetMessageCommand, Result<Message>>
{
    private readonly IAppDbContext dbContext;
    public GetMessageHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Message>> ExecuteAsync(GetMessageCommand command, CancellationToken ct)
    {
        var message = await dbContext.Messages.Where(x => x.Id == command.Id).Include(x => x.User).FirstOrDefaultAsync(ct);
        if (message is null)
        {
            return Result.Fail("Message doest not exist")
               .WithName(nameof(command.Id))
               .WithCode("invalid_user")
               .WithStatus(HttpStatusCode.Unauthorized);
        }
        return message;
    }
}

