namespace Human.Core.Features.Tags.CreateTags;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class CreateTagResult
{
    public required Guid Id { get; set; }
}

[Mapper]
internal static partial class CreateTagResultMapper
{
    public static partial CreateTagResult ToResult(this Tag tag);
}