using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Votes.GetVote;

public sealed class GetVoteHandler : ICommandHandler<GetVoteCommand, Result<Vote>>
{
    private readonly IAppDbContext dbContext;
    public GetVoteHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Vote>> ExecuteAsync(GetVoteCommand command, CancellationToken ct)
    {
        var vote = await dbContext.Votes.Where(x => x.User.Id == command.UserId && x.Message.Id == command.MessageId).FirstOrDefaultAsync(ct);
        if (vote is null)
        {
            return Result.Fail("Vote not found")
                          .WithName(nameof(command.UserId))
                          .WithCode("invalid_vote")
                          .WithStatus(HttpStatusCode.BadRequest);
        }
        return vote;
    }
}