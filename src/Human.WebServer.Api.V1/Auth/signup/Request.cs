using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Auth.Signup;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Auth.Signup;

internal sealed class SignupRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ComfirmPassword { get; set; }
}

internal sealed class Validator : Validator<SignupRequest>
{
    public Validator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password)
            .NotEmpty();
        RuleFor(x => x.ComfirmPassword)
            .NotEmpty();
    }
}

[Mapper]
internal static partial class RequestMapper
{
    public static partial SignupCommand ToCommand(this SignupRequest request);
}