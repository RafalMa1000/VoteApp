using Voting.Application.Common.Interfaces;

namespace Voting.Application.VotingActivities.Commands.CreateVotingActivity;

public class CreateVotingActivityCommandValidator : AbstractValidator<CreateVotingActivityCommand>
{
    private readonly IApplicationDbContext _context;    

    public CreateVotingActivityCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.CandidateId)
            .MustAsync(CandidateExists);
        RuleFor(v => v.VoterId)
            .MustAsync(VoterExists)
            .MustAsync(VoterBeUnique)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    private async Task<bool> CandidateExists(int id, CancellationToken token) =>
        await _context.Candidates.AnyAsync(a => a.Id == id);
    
    private async Task<bool> VoterExists(int id, CancellationToken token) =>
        await _context.Voters.AnyAsync(a => a.Id == id);

    public async Task<bool> VoterBeUnique(int voterId, CancellationToken cancellationToken)
    {
        var hasVoted = await _context.VotingActivities
            .AnyAsync(l => l.VoterId == voterId, cancellationToken);
        return !hasVoted;
    }
}
