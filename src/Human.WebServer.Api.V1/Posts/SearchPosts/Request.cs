using FastEndpoints;
using FluentValidation;
using Riok.Mapperly.Abstractions;
using Human.Core.Features.Posts.SearchPosts;

namespace Human.WebServer.Api.V1.Posts.SearchPosts;

internal sealed class SearchPostsRequest
{
    public required string Input { get; set; }
}
internal sealed class Validator : Validator<SearchPostsRequest>
{
    // public Validator()
    // {

    // }
}


[Mapper]
internal static partial class RequestMapper
{
    public static partial SearchPostsCommand ToCommand(this SearchPostsRequest request);

}