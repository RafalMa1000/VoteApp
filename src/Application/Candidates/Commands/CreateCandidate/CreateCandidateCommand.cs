using Voting.Application.Common.Interfaces;
using Voting.Domain.Entities;

namespace Voting.Application.Candidates.Commands.CreateCandidate;

public record CreateCandidateCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
}

public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCandidateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var entity = new Candidate();

        entity.Name = request?.Name ?? string.Empty;

        _context.Candidates.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
