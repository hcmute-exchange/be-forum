
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Posts.GetPost;

public sealed class GetPostHandler : ICommandHandler<GetPostCommand, Result<Post>>
{
    private readonly IAppDbContext dbContext;
    public GetPostHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Post>> ExecuteAsync(GetPostCommand command, CancellationToken ct)
    {
        var post = await dbContext.Posts.Where(x => x.Id == command.Id).Include(x => x.InitialMessage).Include(x => x.Tags).FirstOrDefaultAsync(ct);
        if (post is null)
        {
            return Result.Fail("Post doest not exist")
               .WithName(nameof(command.Id))
               .WithCode("invalid_user")
               .WithStatus(HttpStatusCode.Unauthorized);
        }
        return post;
    }
}

