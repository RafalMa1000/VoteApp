namespace Voting.Domain.Entities;

public class Voter : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;    
    public List<VotingActivity> VotingActivities { get; set; } = new List<VotingActivity>();
}
