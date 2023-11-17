using FastEndpoints;
using FluentValidation;
using Riok.Mapperly.Abstractions;
using Human.Core.Features.Posts.GetPosts;

namespace Human.WebServer.Api.V1.Posts.GetPosts;

internal sealed class GetPostsRequest
{

}
internal sealed class Validator : Validator<GetPostsRequest>
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
    public static partial GetPostsCommand ToCommand(this GetPostsRequest request);

}