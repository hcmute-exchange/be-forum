using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Messages.GetMessage;
using Response = Results<Ok<GetMessageResponse>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<GetMessageRequest, Response>
{
    public override void Configure()
    {
        Get("message/{Id}");
        Verbs(Http.GET);
        Version(1);
        AllowAnonymous();
    }

    public override async Task<Response> ExecuteAsync(GetMessageRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.Ok(result.Value.ToResponse());
    }
}