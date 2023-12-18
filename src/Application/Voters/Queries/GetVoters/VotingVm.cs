using Voting.Application.Common.Models;

namespace Voting.Application.Voters.Queries.GetVoters;

public class VotingVm
{
    public IReadOnlyCollection<VoterDto> Voters { get; init; } = Array.Empty<VoterDto>();
}
