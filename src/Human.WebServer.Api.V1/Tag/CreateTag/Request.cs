using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Tags.CreateTags;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Tags.CreateTag;

internal sealed class Request
{
    public string? Name { get; set; }
}


internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotNull();
    }
}
[Mapper]

internal static partial class CreateTagCommandMapper
{
    public static partial CreateTagCommand ToCommand(this Request request);
}