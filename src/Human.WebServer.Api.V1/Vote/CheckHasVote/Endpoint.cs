using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Votes.CheckHasVote;

using Response = Results<NoContent, ProblemDetails>;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Head("votes/{MessageId}");
        Verbs(Http.HEAD);
        Version(1);
    }

    public override async Task<Response> ExecuteAsync(Request req, CancellationToken ct)
    {
        Console.WriteLine("asdasd");
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.NoContent();
    }
}