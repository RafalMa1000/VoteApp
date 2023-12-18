using Voting.Application.Common.Interfaces;
using Voting.Domain.Entities;

namespace Voting.Application.VotingActivities.Commands.CreateVotingActivity;

public record CreateVotingActivityCommand : IRequest<int>
{
    public int VoterId { get; set; }
    public int CandidateId { get; set; }
}

public class CreateVotingActivityCommandHandler : IRequestHandler<CreateVotingActivityCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVotingActivityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateVotingActivityCommand request, CancellationToken cancellationToken)
    {
        VotingActivity entity = new() 
        {
            VoterId = request.VoterId,
            CandidateId = request.CandidateId 
        };
                
        _context.VotingActivities.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        var votes = await _context.VotingActivities.CountAsync(c => c.CandidateId == request.CandidateId);

        return votes;
    }
}
