using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Posts.PopularPosts;
using Response = Results<Ok<PopularPostsResponse[]>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<PopularPostsRequest, Response>
{
    public override void Configure()
    {
        Get("popularPosts");
        Verbs(Http.GET);
        Version(1);
        AllowAnonymous();
    }

    public override async Task<Response> ExecuteAsync(PopularPostsRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }
        return TypedResults.Ok(result.Value.ToResponse());
    }
}