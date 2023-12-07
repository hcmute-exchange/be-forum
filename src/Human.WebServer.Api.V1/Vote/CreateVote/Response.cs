namespace Human.WebServer.Api.V1.Votes.CreateVote;

using Human.Domain.Models;
using Riok.Mapperly.Abstractions;
public class VoteResponse
{
}

[Mapper]
internal static partial class ResponseMapper
{
    public static partial VoteResponse ToResponse(this Vote tag);
}