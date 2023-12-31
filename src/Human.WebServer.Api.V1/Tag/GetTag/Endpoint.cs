using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Tags.GetTag;

using Response = Results<Ok<GetTagResponse>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("tags/{Id}");
        Verbs(Http.GET);
        Version(1);
    }

    public override async Task<Response> ExecuteAsync(Request req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.Ok(result.Value.ToResponse());
    }
}