using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Views.CreateViews;

public sealed class CreateViewHandler : ICommandHandler<CreateViewCommand, Result<View>>
{
    private readonly IAppDbContext dbContext;
    public CreateViewHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<View>> ExecuteAsync(CreateViewCommand command, CancellationToken ct)
    {
        var post = await dbContext.Posts.Where(x => x.Id == command.PostId).FirstOrDefaultAsync(ct);
        if (post is null)
        {
            return Result.Fail("Post not found")
              .WithName(nameof(command.PostId))
              .WithCode("invalid_Post")
              .WithStatus(HttpStatusCode.BadRequest);
        }
        var view = new View
        {
            Post = post
        };
        dbContext.Attach(post);
        dbContext.Add(view);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return view;
    }
}