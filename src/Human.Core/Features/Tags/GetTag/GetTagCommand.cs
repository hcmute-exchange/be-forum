using FastEndpoints;
using FluentResults;
using Human.Domain.Models;

namespace Human.Core.Features.Tags.GetTag;

public class GetTagCommand : ICommand<Result<Tag>>
{
    public required Guid Id { get; set; }
}
