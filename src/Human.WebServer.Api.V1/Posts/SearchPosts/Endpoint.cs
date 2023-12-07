using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Posts.SearchPosts;
using Response = Results<Ok<SearchPostsResponse[]>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<SearchPostsRequest, Response>
{
    public override void Configure()
    {
        Get("posts/{Input}");
        Verbs(Http.GET);
        Version(1);
        AllowAnonymous();
    }

    public override async Task<Response> ExecuteAsync(SearchPostsRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }
        return TypedResults.Ok(result.Value.ToResponse());
    }
}