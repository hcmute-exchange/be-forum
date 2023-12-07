using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Votes.CheckHasVote;

public sealed class CheckHasVoteHandler : ICommandHandler<CheckHasVoteCommand, Result<Vote>>
{
    private readonly IAppDbContext dbContext;
    public CheckHasVoteHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Vote>> ExecuteAsync(CheckHasVoteCommand command, CancellationToken ct)
    {
        var vote = await dbContext.Votes.Where(x => x.User.Id == command.UserId && x.Message.Id == command.MessageId).FirstOrDefaultAsync(ct);
        if (vote is not null)
        {
            return Result.Fail("Vote already exists")
                          .WithName(nameof(command.UserId))
                          .WithCode("invalid_vote")
                          .WithStatus(HttpStatusCode.BadRequest);
        }
        return Result.Ok();
    }
}