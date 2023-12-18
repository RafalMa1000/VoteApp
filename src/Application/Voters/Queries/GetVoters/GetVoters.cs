using Voting.Application.Common.Interfaces;
using Voting.Application.Common.Security;

namespace Voting.Application.Voters.Queries.GetVoters;

[Authorize]
public record GetVoters : IRequest<VotingVm>;

public class GetVotersQueryHandler : IRequestHandler<GetVoters, VotingVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVotersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VotingVm> Handle(GetVoters request, CancellationToken cancellationToken)
    {
        var voter = new VotingVm
        {
            Voters = await _context.Voters
                .AsNoTracking()
                .ProjectTo<VoterDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
        return voter;
    }
}
