using FastEndpoints;
using FluentResults;
using Human.Domain.Models;

namespace Human.Core.Features.Tags.GetTags;

public class GetTagsCommand : ICommand<Result<Tag[]>>
{
}
