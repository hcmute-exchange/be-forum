using System.Net;
using System.Security.Claims;
using FastEndpoints;
using FluentResults;
using Human.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Human.Core.Features.Auth.Login;

public sealed class LoginHandler : ICommandHandler<LoginCommand, Result<LoginResult>>
{
    private readonly IAppDbContext dbContext;
    private readonly IJwtBearerService jwtBearerService;

    public LoginHandler(IAppDbContext dbContext, IJwtBearerService jwtBearerService)
    {
        this.dbContext = dbContext;
        this.jwtBearerService = jwtBearerService;
    }

    public async Task<Result<LoginResult>> ExecuteAsync(LoginCommand command, CancellationToken ct)
    {
        var user = await dbContext.Users.Where(x => x.Email == command.Email)
            .Select(x => new { x.Id, x.PasswordHash })
            .FirstOrDefaultAsync(cancellationToken: ct)
            .ConfigureAwait(false);
        if (user is null)
        {
            return Result.Fail("Login credentials is not correct")
                .WithName(nameof(command.Email))
                .WithCode("user_not_found")
                .WithStatus(HttpStatusCode.Unauthorized);
        }

        if (!BCrypt.Net.BCrypt.EnhancedVerify(command.Password, user.PasswordHash))
        {
            return Result.Fail("Login credentials is not correct")
                .WithName(nameof(command.Password))
                .WithCode("wrong_credentials")
                .WithStatus(HttpStatusCode.Unauthorized);
        }

        var permissions = await dbContext.UserPermissions
            .Where(x => x.User.Id == user.Id)
            .Select(x => x.Permission)
            .ToArrayAsync()
            .ConfigureAwait(false);

        return new LoginResult
        {
            AccessToken = jwtBearerService.Sign(
                privileges =>
                {
                    privileges.Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    privileges.Permissions.AddRange(permissions);
                },
                expireAt: DateTimeOffset.UtcNow.AddMinutes(5).UtcDateTime),
            RefreshToken = Guid.NewGuid().ToString()
        };
    }
}