using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Views.CreateView;

using Response = Results<Ok<ViewResponse>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("views");
        Verbs(Http.POST);
        Version(1);
        AllowAnonymous();
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