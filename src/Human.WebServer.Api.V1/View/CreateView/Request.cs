using FastEndpoints;
using FluentValidation;
using Human.Core.Features.Views.CreateViews;
using Riok.Mapperly.Abstractions;

namespace Human.WebServer.Api.V1.Views.CreateView;

internal sealed class Request
{
    public Guid PostId { get; set; }
}


internal sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.PostId)
            .NotNull();
    }
}
[Mapper]

internal static partial class CreateViewCommandMapper
{
    public static partial CreateViewCommand ToCommand(this Request request);
}