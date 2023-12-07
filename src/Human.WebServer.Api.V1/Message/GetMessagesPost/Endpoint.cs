using FastEndpoints;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Messages.GetMessagesPost;
using Response = Results<Ok<GetMessagesPostResponse[]>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<GetMessagesPostRequest, Response>
{
    public override void Configure()
    {
        Get("messagesPost");
        Verbs(Http.GET);
        Version(1);
        AllowAnonymous();
    }

    public override async Task<Response> ExecuteAsync(GetMessagesPostRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }
        Console.WriteLine(result.Value.ToResponse());
        return TypedResults.Ok(result.Value.ToResponse());
    }
}