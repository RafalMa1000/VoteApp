using Voting.Application.Candidates.Commands.CreateCandidate;
using Voting.Application.Candidates.Queries.GetCandidates;

namespace Voting.Web.Endpoints;

public class Candidates : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCandidates)
            .MapPost(CreateCandidates);
    }

    public async Task<CandidatesVm> GetCandidates(ISender sender)
    {
        return await sender.Send(new GetCandidates());
    }

    public async Task<int> CreateCandidates(ISender sender, CreateCandidateCommand command)
    {
        return await sender.Send(command);
    }
}
