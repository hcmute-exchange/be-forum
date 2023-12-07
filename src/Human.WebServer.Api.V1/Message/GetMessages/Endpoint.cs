using FastEndpoints;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Messages.GetMessages;
using Response = Results<Ok<GetMessagesResponse[]>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<GetMessagesRequest, Response>
{
    public override void Configure()
    {
        Get("messages");
        Verbs(Http.GET);
        Version(1);
        AllowAnonymous();
    }

    public override async Task<Response> ExecuteAsync(GetMessagesRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }
        return TypedResults.Ok(result.Value.ToResponse());
    }
}