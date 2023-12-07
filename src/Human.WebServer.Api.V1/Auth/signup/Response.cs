using Human.Core.Features.Auth.Login;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Auth.Signup;

internal sealed class SignupResponse
{

}


[Mapper]
internal static partial class ResponseMapper
{
    public static partial SignupResponse ToResponse(this User result);
}