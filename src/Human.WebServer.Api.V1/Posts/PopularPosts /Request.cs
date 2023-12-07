using FastEndpoints;
using FluentValidation;
using Riok.Mapperly.Abstractions;
using Human.Core.Features.Posts.PopularPosts;

namespace Human.WebServer.Api.V1.Posts.PopularPosts;

internal sealed class PopularPostsRequest
{

}
internal sealed class Validator : Validator<PopularPostsRequest>
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
    public static partial PopularPostsCommand ToCommand(this PopularPostsRequest request);

}