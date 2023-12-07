using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Auth.Signup;

public sealed class SignupCommand : ICommand<Result<User>>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ComfirmPassword { get; set; }
}

[Mapper]
internal static partial class SignupCommandMapper
{
    [MapProperty(nameof(command.Password), nameof(User.PasswordHash))]
    public static partial User ToUser(this SignupCommand command);
}