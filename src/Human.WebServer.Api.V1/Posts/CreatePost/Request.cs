using System.Security.Claims;
using FastEndpoints;
using FluentValidation;

namespace Human.WebServer.Api.V1.Posts.CreatePost;

internal sealed class Request
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public Guid UserId { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public String[]? Name { get; set; }

}
internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Subject)
            .NotNull();
        RuleFor(x => x.Body)
            .NotNull();
        RuleFor(x => x.Name)
            .NotNull();
    }
}
