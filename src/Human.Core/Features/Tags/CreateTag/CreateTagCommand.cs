using FastEndpoints;
using FluentResults;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.Tags.CreateTags;

public class CreateTagCommand : ICommand<Result<Tag>>
{
    public required string Name { get; set; }
}

[Mapper]
internal static partial class CreateTagCommandMapper
{
    public static partial Tag ToTag(this CreateTagCommand command);
}