
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Tags.GetTag;

public sealed class GetTagHandler : ICommandHandler<GetTagCommand, Result<Tag>>
{
    private readonly IAppDbContext dbContext;
    public GetTagHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Tag>> ExecuteAsync(GetTagCommand command, CancellationToken ct)
    {
        var tag = await dbContext.Tags.Where(x => x.Id == command.Id).FirstOrDefaultAsync(ct);
        return tag;
    }
}

