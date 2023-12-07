using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Posts.NewestPosts;
using Response = Results<Ok<NewestPostsResponse[]>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<NewestPostsRequest, Response>
{
    public override void Configure()
    {
        Get("newestPosts");
        Verbs(Http.GET);
        Version(1);
        AllowAnonymous();
    }

    public override async Task<Response> ExecuteAsync(NewestPostsRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }
        return TypedResults.Ok(result.Value.ToResponse());
    }
}