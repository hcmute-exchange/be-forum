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
        var anyUser = await dbContext.Users.AnyAsync(x => x.Id == command.UserId, cancellationToken: ct)
        .ConfigureAwait(false);


        if (!anyUser)
        {
            return Result.Fail("User does not exist")
               .WithName(nameof(command.UserId))
               .WithCode("invalid_user")
               .WithStatus(HttpStatusCode.Unauthorized);
        }
        Console.WriteLine(command.PostId);
        var anyPost = await dbContext.Posts.AnyAsync(x => x.Id == command.PostId, cancellationToken: ct)
        .ConfigureAwait(false);


        if (!anyPost)
        {
            return Result.Fail("Post doest not exist")
               .WithName(nameof(command.PostId))
               .WithCode("invalid_user")
               .WithStatus(HttpStatusCode.Unauthorized);
        }
        var user = new User
        {
            Id = command.UserId
        };
        var post = new Post
        {
            Id = command.PostId
        };

        var message = command.ToMessage(user);
        message.Post = post;
        dbContext.Attach(user);
        dbContext.Attach(post);
        dbContext.Add(message);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return message;
    }
}