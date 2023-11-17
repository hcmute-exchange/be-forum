using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Posts.GetPost;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Posts.GetPost;

internal sealed class GetPostRequest
{
    public Guid? Id { get; set; }

}
internal sealed class Validator : Validator<GetPostRequest>
{
    public Validator()
    {
        RuleFor(x => x.Id)
            .NotNull();
    }
}


[Mapper]
internal static partial class RequestMapper
{
    public static partial GetPostCommand ToCommand(this GetPostRequest request);

}