
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Posts.PopularPosts;

public sealed class PopularPostsHandler : ICommandHandler<PopularPostsCommand, Result<Post[]>>
{
    private readonly IAppDbContext dbContext;
    public PopularPostsHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Post[]>> ExecuteAsync(PopularPostsCommand command, CancellationToken ct)
    {
        var posts = await dbContext.Posts.Include(x => x.InitialMessage).ThenInclude(x => x.User).Include(x => x.InitialMessage).ThenInclude(x => x.Votes).Include(x => x.Tags).Include(x => x.Views).Where(post => post.InitialMessage.Votes.Count > 2 && post.Views.Count > 3).ToArrayAsync(ct);
        return posts;
    }
}

