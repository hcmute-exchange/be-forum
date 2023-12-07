using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Votes.DeleteVotes;

public sealed class DeleteVoteHandler : ICommandHandler<DeleteVoteCommand, Result<Vote>>
{
    private readonly IAppDbContext dbContext;
    public DeleteVoteHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Vote>> ExecuteAsync(DeleteVoteCommand command, CancellationToken ct)
    {
        var count = await dbContext.Votes
        .Include(v => v.User)
        .Include(v => v.Message)
        .Where(x => x.User.Id == command.UserId && x.Message.Id == command.MessageId)
        .ExecuteDeleteAsync(ct)
        .ConfigureAwait(false);

        if (count == 0)
        {
            return Result.Fail("Vote doesnt exists")
                          .WithName(nameof(command.UserId))
                          .WithCode("invalid_vote")
                          .WithStatus(HttpStatusCode.BadRequest);
        }
        return Result.Ok();
    }
}