
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Posts.GetPosts;

public sealed class GetPostsHandler : ICommandHandler<GetPostsCommand, Result<Post[]>>
{
    private readonly IAppDbContext dbContext;
    public GetPostsHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Post[]>> ExecuteAsync(GetPostsCommand command, CancellationToken ct)
    {
        var posts = await dbContext.Posts.Include(x => x.InitialMessage).ThenInclude(x => x.User).Include(x => x.Tags).ToArrayAsync(ct);
        return posts;
    }
}

