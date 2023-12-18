using Voting.Application.Common.Interfaces;
using Voting.Domain.Entities;

namespace Voting.Application.Voters.Commands.CreateVoter;

public record CreateVoterCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
}

public class CreateVoterCommandHandler : IRequestHandler<CreateVoterCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVoterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateVoterCommand request, CancellationToken cancellationToken)
    {
        var entity = new Voter();

        entity.Name = request?.Name ?? string.Empty;

        _context.Voters.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
