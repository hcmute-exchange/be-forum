using Riok.Mapperly.Abstractions;
using Human.Domain.Models;

namespace Human.WebServer.Api.V1.Votes.GetVotes;

public class GetVoteResponse
{
    public int Weight { get; set; }
}


[Mapper]
internal static partial class ResponseMapper
{
    public static partial GetVoteResponse ToResponse(this Vote result);
}