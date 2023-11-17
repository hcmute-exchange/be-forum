using FastEndpoints;
using Human.Core.Features.Tags.GetTags;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Tags.GetTags;

internal sealed class Request
{
}


internal sealed class Validator : Validator<Request>
{
    // public Validator()
    // {
    //     RuleFor(x => x.Id)
    //         .NotNull();
    // }
}
[Mapper]

internal static partial class GetTagsCommandMapper
{
    public static partial GetTagsCommand ToCommand(this Request request);
}