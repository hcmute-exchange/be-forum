
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Messages.GetMessages;

public sealed class GetMessagesHandler : ICommandHandler<GetMessagesCommand, Result<Message[]>>
{
    private readonly IAppDbContext dbContext;
    public GetMessagesHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Message[]>> ExecuteAsync(GetMessagesCommand command, CancellationToken ct)
    {
        var messages = await dbContext.Messages.Include(x => x.User).Include(x => x.Votes).ToArrayAsync(ct);
        return messages;
    }
}

