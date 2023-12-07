using FastEndpoints;
using FluentResults;
using Human.WebServer.Api.V1.Auth.Signup;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Human.WebServer.Api.V1.Auth.Signup;

using Response = Results<Ok<SignupResponse>, ProblemDetails>;

internal sealed class Endpoint : Endpoint<SignupRequest, Response>
{
    public override void Configure()
    {
        Post("auth/signup");
        Verbs(Http.POST);
        Version(1);
        AllowAnonymous();
    }

    public override async Task<Response> ExecuteAsync(SignupRequest req, CancellationToken ct)
    {
        var result = await req.ToCommand().ExecuteAsync(ct).ConfigureAwait(false);
        if (result.IsFailed)
        {
            return this.ProblemDetails(result.Errors);
        }

        return TypedResults.Ok(result.Value.ToResponse());
    }
}