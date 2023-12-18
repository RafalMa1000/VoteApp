using Voting.Domain.Entities;

namespace Voting.Application.Candidates.Queries.GetCandidates;

public class CandidateDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public int VotesCount { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Candidate, CandidateDto>()
                .ForMember(d => d.VotesCount, o => o.MapFrom(s => s.VotingActivities.Count));
        }
    }
}
