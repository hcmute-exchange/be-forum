using Riok.Mapperly.Abstractions;
using Human.Domain.Models;

namespace Human.WebServer.Api.V1.Votes.PutVotes;

public class PutVoteResponse
{
}


[Mapper]
internal static partial class ResponseMapper
{
    public static partial PutVoteResponse ToResponse(this Vote result);
}