using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Tags.GetTag;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Tags.GetTag;

internal sealed class Request
{
    public Guid? Id { get; set; }
}


internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id)
            .NotNull();
    }
}
[Mapper]

internal static partial class GetTagCommandMapper
{
    public static partial GetTagCommand ToCommand(this Request request);
}