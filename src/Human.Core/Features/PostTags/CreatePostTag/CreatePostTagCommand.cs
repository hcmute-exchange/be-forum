using FastEndpoints;
using FluentResults;
using Human.Core.Features.Tags.CreateTags;
using Human.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Human.Core.Features.PostTags.CreatePostTag;

public class CreatePostTagCommand : ICommand<Result<CreatePostTagResult>>
{
    public required CreateTagCommand TagCommand { get; set; }
}

[Mapper]
internal static partial class CreatePostTagCommandMapper
{
    public static partial PostTag ToPostTag(this CreatePostTagCommand command);
    public static PostTag ToPostTag(this CreatePostTagCommand command, CreateTagCommand tagCommand)
    {
        return command.ToPostTag() with { Tag = tagCommand.ToTag() };
    }
}