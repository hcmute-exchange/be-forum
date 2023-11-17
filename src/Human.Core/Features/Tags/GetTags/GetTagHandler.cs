
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Tags.GetTags;

public sealed class GetTagsHandler : ICommandHandler<GetTagsCommand, Result<Tag[]>>
{
    private readonly IAppDbContext dbContext;
    public GetTagsHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Tag[]>> ExecuteAsync(GetTagsCommand command, CancellationToken ct)
    {
        var tags = await dbContext.Tags.ToArrayAsync(ct);
        return tags;
    }
}

