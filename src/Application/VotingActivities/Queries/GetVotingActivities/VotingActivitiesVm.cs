using Voting.Application.Common.Models;

namespace Voting.Application.Voters.Queries.GetVoters;

public class VotingActivitiesVm
{
    public IReadOnlyCollection<VotingActivitiesDto> Votes { get; init; } = Array.Empty<VotingActivitiesDto>();
}
