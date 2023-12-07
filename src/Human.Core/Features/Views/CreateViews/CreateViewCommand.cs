using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Views.CreateViews;

public class CreateViewCommand : ICommand<Result<View>>
{
    public Guid? PostId { get; set; }
}

[Mapper]
internal static partial class CreateViewCommandMapper
{
    public static partial View ToView(this CreateViewCommand command);
}