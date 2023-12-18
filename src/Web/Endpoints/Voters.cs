using Voting.Application.Voters.Commands.CreateVoter;
using Voting.Application.Voters.Queries.GetVoters;

namespace Voting.Web.Endpoints;

public class Voters : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetVoters)
            .MapPost(CreateVoters);
    }

    public async Task<VotingVm> GetVoters(ISender sender)
    {
        return await sender.Send(new GetVoters());
    }

    public async Task<int> CreateVoters(ISender sender, CreateVoterCommand command)
    {
        return await sender.Send(command);
    }
}
