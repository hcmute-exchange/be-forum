
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Messages.GetMessagesPost;

public sealed class GetMessagesPostHandler : ICommandHandler<GetMessagesPostCommand, Result<Message[]>>
{
    private readonly IAppDbContext dbContext;
    public GetMessagesPostHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Message[]>> ExecuteAsync(GetMessagesPostCommand command, CancellationToken ct)
    {
        var messages = await dbContext.Messages
            .Where(x => x.Post.Id == command.PostId)
            .Include(x => x.Votes)
            .ThenInclude(x => x.User)
            .Include(x => x.User)
            .OrderBy(x => x.CreatedTime)
            .ToArrayAsync(ct);
        return messages;
    }
}

