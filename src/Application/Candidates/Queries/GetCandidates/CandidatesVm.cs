namespace Voting.Application.Candidates.Queries.GetCandidates;

public class CandidatesVm
{
    public IReadOnlyCollection<CandidateDto> Candidates { get; init; } = Array.Empty<CandidateDto>();
}
