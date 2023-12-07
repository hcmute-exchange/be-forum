using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Human.WebServer.Api.V1.Votes.PutVotes;

using Response = Results<NoContent, ProblemDetails>;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Put("votes");
        Verbs(Http.PUT);
        Version(1);
    }

    public override async Task<Response> ExecuteAsync(Request req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.NoContent();
    }
}