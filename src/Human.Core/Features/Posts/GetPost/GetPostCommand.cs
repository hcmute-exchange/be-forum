using FastEndpoints;
using FluentResults;
using Human.Domain.Models;

namespace Human.Core.Features.Posts.GetPost;

public class GetPostCommand : ICommand<Result<Post>>
{
    public required Guid Id { get; set; }
}
