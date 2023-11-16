
using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Features.Posts.CreatePost;
using Human.Core.Features.PostTags.CreatePostTag;
using Human.Core.Interfaces;
using Human.Domain.Models;
namespace Human.Core.Features.Posts.CreatePost;

public sealed class CreatePostHandler : ICommandHandler<CreatePostCommand, Result<CreatePostResult>>
{
    private readonly IAppDbContext dbContext;
    public CreatePostHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<CreatePostResult>> ExecuteAsync(CreatePostCommand command, CancellationToken ct)
    {
        var createMessageResult = await command.InitialMessage.ExecuteAsync(ct);
        if (createMessageResult.IsFailed)
        {
            return Result.Fail(createMessageResult.Errors);
        }
        var post = new Post
        {
            Subject = command.Subject,
            InitialMessage = createMessageResult.Value
        };
        foreach (var id in command.TagIds)
        {
            var tag = new Tag
            {
                Id = id
            };
            dbContext.Attach(tag);
            dbContext.Add(new PostTag
            {
                Tag = tag,
                Post = post
            });
        }
        dbContext.Add(post);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return post.ToResult();
    }
}