using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Posts.PopularPosts;

public class PopularPostsCommand : ICommand<Result<Post[]>>
{

}

[Mapper]
internal static partial class CreateThreadCommandMapper
{
    public static partial Post ToPost(this PopularPostsCommand command);
}