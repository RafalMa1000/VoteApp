using Voting.Application.Candidates.Queries.GetCandidates;
using Voting.Domain.Entities;

namespace Voting.Application.Voters.Queries.GetVoters;

public class VotingActivitiesDto
{
    public int Id { get; init; }
    public VoterDto? Voter { get; set; }
    public CandidateDto? Candidate { get; set; }    

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<VotingActivity, VotingActivitiesDto>()
                .ForMember(d => d.Voter, o => o.MapFrom(s => s.Voter))
                .ForMember(d => d.Candidate, o => o.MapFrom(s => s.Candidate));                
        }
    }
}
