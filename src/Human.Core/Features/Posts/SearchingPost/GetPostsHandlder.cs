
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Posts.SearchPosts;

public sealed class SearchPostsHandler : ICommandHandler<SearchPostsCommand, Result<Post[]>>
{
    private readonly IAppDbContext dbContext;
    public SearchPostsHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Post[]>> ExecuteAsync(SearchPostsCommand command, CancellationToken ct)
    {
        var query = await dbContext.Posts.Where(p => p.SearchVector.Matches(command.Input) || p.InitialMessage.SearchVector.Matches(command.Input)).Include(x => x.InitialMessage).ThenInclude(x => x.User).Include(x => x.InitialMessage).ThenInclude(x => x.Votes).Include(x => x.Tags).Include(x => x.Views).ToArrayAsync(ct);
        return query;
    }
}

