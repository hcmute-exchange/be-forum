using System.Net;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Human.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Human.Core.Features.Auth.Signup;

public sealed class SignupHandler : ICommandHandler<SignupCommand, Result<User>>
{
    private readonly IAppDbContext dbContext;

    public SignupHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<User>> ExecuteAsync(SignupCommand command, CancellationToken ct)
    {
        var any = await dbContext.Users.AnyAsync(x => x.Email == command.Email, ct).ConfigureAwait(false);
        if (any)
        {
            return Result.Fail("Email already exists")
              .WithName(nameof(command.Email))
              .WithCode("duplicated_email")
              .WithStatus(HttpStatusCode.BadRequest);
        }
        if (command.Password != command.ComfirmPassword)
        {
            return Result.Fail("Password doesnt match")
              .WithName(nameof(command.Password))
              .WithCode("notmatch_password")
              .WithStatus(HttpStatusCode.BadRequest);
        }
        command.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(command.Password);
        var user = command.ToUser();
        dbContext.Add(user);
        await dbContext.SaveChangesAsync(ct).ConfigureAwait(false);
        return user;
    }
}