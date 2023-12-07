using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Votes.PutVotes;

public sealed class PutVoteHandler : ICommandHandler<PutVoteCommand, Result<Vote>>
{
    private readonly IAppDbContext dbContext;
    public PutVoteHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Vote>> ExecuteAsync(PutVoteCommand command, CancellationToken ct)
    {
        var vote = await dbContext.Votes
        .Where(x => x.User.Id == command.UserId && x.Message.Id == command.MessageId)
        .Include(v => v.User)
        .Include(v => v.Message)
        .ExecuteUpdateAsync(x => x.SetProperty(b => b.Weight, -1), ct)
        .ConfigureAwait(false);
        if (vote == 0)
        {
            return Result.Fail("Vote not found")
                          .WithName(nameof(command.UserId))
                          .WithCode("invalid_vote")
                           .WithStatus(HttpStatusCode.BadRequest);
        }
        return Result.Ok();
    }
}