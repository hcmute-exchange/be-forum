using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Posts.NewestPosts;

public class NewestPostsCommand : ICommand<Result<Post[]>>
{

}

[Mapper]
internal static partial class CreateThreadCommandMapper
{
    public static partial Post ToPost(this NewestPostsCommand command);
}