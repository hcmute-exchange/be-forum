
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
namespace Human.Core.Features.Posts.CreatePost;

public sealed class CreatePostHandler : ICommandHandler<CreatePostCommand, Result<CreatePostResult>>
{
    private readonly IAppDbContext dbContext;
    public CreatePostHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<CreatePostResult>> ExecuteAsync(CreatePostCommand command, CancellationToken ct)
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
        var user = new User
        {
            Id = command.UserId
        };
        var message = new Message
        {
            Body = command.Body,
            User = user
        };

        var post = new Post
        {
            Subject = command.Subject,
            InitialMessage = message
        };
        dbContext.Add(message);
        dbContext.Attach(user);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        foreach (var tag in command.Tags)
        {
            dbContext.Attach(tag);
            post.Tags.Add(tag);
        }
        message.Post = post;
        dbContext.Add(post);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return post.ToResult();
    }
}