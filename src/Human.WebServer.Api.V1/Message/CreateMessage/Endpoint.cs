using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Human.WebServer.Api.V1.Messages.CreateMessage;

using Response = Results<Ok<MessageResponse>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("messages");
        Verbs(Http.POST);
        Version(1);
    }

    public override async Task<Response> ExecuteAsync(Request req, CancellationToken ct)
    {
        Console.Write(req.UserId);
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.Ok(result.Value.ToResponse());
    }
}