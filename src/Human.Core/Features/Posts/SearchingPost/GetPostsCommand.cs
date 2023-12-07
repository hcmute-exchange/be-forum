using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Posts.SearchPosts;

public class SearchPostsCommand : ICommand<Result<Post[]>>
{
    public required string Input { get; set; }
}

[Mapper]
internal static partial class CreateThreadCommandMapper
{
    public static partial Post ToPost(this SearchPostsCommand command);
}