namespace Voting.Domain.Entities;

public class VotingActivity : BaseAuditableEntity
{
    public int VoterId { get; set; }
    public int CandidateId { get; set; }
    public Voter? Voter { get; set; }
    public Candidate? Candidate { get; set; }
}
