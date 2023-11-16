namespace Human.Core.Features.PostTags.CreatePostTag;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class CreatePostTagResult
{
    public required Guid Id { get; set; }
}



[Mapper]
internal static partial class CreatePostTagResultMapper
{
    public static partial CreatePostTagResult ToResult(this PostTag postTag);
}