using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Human.Core.Features.Tags.CreateTags;

public sealed class CreateTagHandler : ICommandHandler<CreateTagCommand, Result<Tag>>
{
    private readonly IAppDbContext dbContext;
    public CreateTagHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<Tag>> ExecuteAsync(CreateTagCommand command, CancellationToken ct)
    {
        var any = await dbContext.Tags.AnyAsync(x => x.Name == command.Name, cancellationToken: ct)
            .ConfigureAwait(false);
        if (any)
        {
            return Result.Fail("Name already exists")
               .WithName(nameof(command.Name))
               .WithCode("invalid_name")
               .WithStatus(HttpStatusCode.BadRequest);
        }
        var tag = new Tag
        {
            Name = command.Name
        };
        dbContext.Add(tag);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return tag;
    }
}