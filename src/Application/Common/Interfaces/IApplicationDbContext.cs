using Voting.Domain.Entities;

namespace Voting.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Voter> Voters { get; }

    DbSet<Candidate> Candidates { get; }

    DbSet<VotingActivity> VotingActivities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
