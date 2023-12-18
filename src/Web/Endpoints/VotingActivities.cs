using Voting.Application.Voters.Queries.GetVoters;
using Voting.Application.VotingActivities.Commands.CreateVotingActivity;

namespace Voting.Web.Endpoints;

public class VotingActivities : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetVotingActivity)
            .MapPost(CreateVotingActivity);
    }
    public async Task<VotingActivitiesVm> GetVotingActivity(ISender sender)
    {
        return await sender.Send(new GetVotingActivities());
    }

    public async Task<int> CreateVotingActivity(ISender sender, CreateVotingActivityCommand command)
    {
        return await sender.Send(command);
    }
}
