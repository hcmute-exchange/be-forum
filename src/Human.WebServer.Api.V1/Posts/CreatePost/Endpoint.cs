using FastEndpoints;
using Human.Core.Features.Messages.CreateMessage;
using Human.Core.Features.Posts.CreatePost;
using Microsoft.AspNetCore.Http.HttpResults;
using Human.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using Human.Domain.Models;
using Org.BouncyCastle.Ocsp;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Human.WebServer.Api.V1.Posts.CreatePost;
using Response = Results<Ok<PostResponse>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    private readonly IAppDbContext dbContext;
    public Endpoint(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public override void Configure()
    {
        Post("post");
        Verbs(Http.POST);
        Version(1);
    }

    public override async Task<Response> ExecuteAsync(Request req, CancellationToken ct)
    {
        var dbTags = await dbContext.Tags.Where(x => req.Name!.Contains(x.Name)).Select(x => new Tag { Id = x.Id, Name = x.Name }).ToArrayAsync(ct);
        var newNames = req.Name!.ToHashSet();
        newNames.SymmetricExceptWith(dbTags.Select(x => x.Name));
        var newTags = newNames.Select(x =>
        {
            var tag = new Tag
            {
                Name = x
            };
            Console.WriteLine(dbContext.Add(tag));
            Console.WriteLine("234234");
            return tag;
        }).ToArray();
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        dbContext.ChangeTracker.Clear();
        Console.WriteLine("asdasd");
        Console.WriteLine(string.Join(',', newTags.Select(x => x.Id)));
        Console.WriteLine("123123");
        Console.WriteLine(string.Join(',', dbTags.Concat(newTags).Select(x => x.Id)));
        var result = await new CreatePostCommand
        {
            Subject = req.Subject!,
            Tags = dbTags.Concat(newTags).ToArray(),
            Body = req.Body!,
            UserId = req.UserId!,
        }.ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.Ok(result.Value.ToResponse());
    }
}