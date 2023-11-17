using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Posts.GetPosts;
using Response = Results<Ok<GetPostsResponse[]>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<GetPostsRequest, Response>
{
    public override void Configure()
    {
        Get("posts");
        Verbs(Http.GET);
        Version(1);
    }

    public override async Task<Response> ExecuteAsync(GetPostsRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.Ok(result.Value.ToResponse());
    }
}