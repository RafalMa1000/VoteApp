using Voting.Domain.Entities;

namespace Voting.Application.Voters.Queries.GetVoters;

public class VoterDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public bool HasVoted { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Voter, VoterDto>()
                .ForMember(d => d.HasVoted, o => o.MapFrom(s => s.VotingActivities.Any())); ;
        }
    }
}
