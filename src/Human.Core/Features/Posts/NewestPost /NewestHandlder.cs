
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Posts.NewestPosts;

public sealed class NewestPostsHandler : ICommandHandler<NewestPostsCommand, Result<Post[]>>
{
    private readonly IAppDbContext dbContext;
    public NewestPostsHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Post[]>> ExecuteAsync(NewestPostsCommand command, CancellationToken ct)
    {
        var posts = await dbContext.Posts.Include(x => x.InitialMessage).ThenInclude(x => x.User).Include(x => x.InitialMessage).ThenInclude(x => x.Votes).Include(x => x.Tags).Include(x => x.Views)
        .OrderByDescending(post => post.CreatedTime)
        .Take(5)
        .ToArrayAsync(ct);
        return posts;
    }
}

