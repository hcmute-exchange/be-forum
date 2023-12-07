using Riok.Mapperly.Abstractions;
using Human.Domain.Models;

namespace Human.WebServer.Api.V1.Votes.DeleteVotes;

public class DeleteVoteResponse
{
}


[Mapper]
internal static partial class ResponseMapper
{
    public static partial DeleteVoteResponse ToResponse(this Vote result);
}