using FastEndpoints;
using FluentValidation;
using Riok.Mapperly.Abstractions;
using Human.Core.Features.Posts.NewestPosts;

namespace Human.WebServer.Api.V1.Posts.NewestPosts;

internal sealed class NewestPostsRequest
{

}
internal sealed class Validator : Validator<NewestPostsRequest>
{
    // public Validator()
    // {
    //     // RuleFor(x => x.Id)
    //     //     .NotNull();
    // }
}


[Mapper]
internal static partial class RequestMapper
{
    public static partial NewestPostsCommand ToCommand(this NewestPostsRequest request);

}