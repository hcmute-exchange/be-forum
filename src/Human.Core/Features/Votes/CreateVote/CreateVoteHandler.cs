using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Votes.CreateVotes;

public sealed class CreateVoteHandler : ICommandHandler<CreateVoteCommand, Result<Vote>>
{
    private readonly IAppDbContext dbContext;
    public CreateVoteHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Vote>> ExecuteAsync(CreateVoteCommand command, CancellationToken ct)
    {
        var message = await dbContext.Messages.Where(x => x.Id == command.MessageId).FirstOrDefaultAsync(ct);

        if (message is null)
        {
            return Result.Fail("Message doesnt exists")
               .WithName(nameof(command.MessageId))
               .WithCode("invalid_Message")
               .WithStatus(HttpStatusCode.BadRequest);
        }
        var user = await dbContext.Users.Where(x => x.Id == command.UserId).FirstOrDefaultAsync(ct);
        if (user is null)
        {
            return Result.Fail("User doesnt exists")
               .WithName(nameof(command.UserId))
               .WithCode("invalid_User")
               .WithStatus(HttpStatusCode.BadRequest);
        }
        int Weight = 1;
        Console.WriteLine(user);
        var vote = new Vote
        {
            User = user,
            Weight = Weight,
            Message = message
        };
        dbContext.Attach(message);
        dbContext.Attach(user);
        dbContext.Add(vote);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return vote;
    }
}