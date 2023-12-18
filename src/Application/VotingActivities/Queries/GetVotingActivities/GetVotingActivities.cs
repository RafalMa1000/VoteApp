using Voting.Application.Common.Interfaces;
using Voting.Application.Common.Security;

namespace Voting.Application.Voters.Queries.GetVoters;

[Authorize]
public record GetVotingActivities : IRequest<VotingActivitiesVm>;

public class GetVotingActivitiesQueryHandler : IRequestHandler<GetVotingActivities, VotingActivitiesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVotingActivitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VotingActivitiesVm> Handle(GetVotingActivities request, CancellationToken cancellationToken)
    {
        return new VotingActivitiesVm
        {
            Votes = await _context.VotingActivities
                .AsNoTracking()
                .ProjectTo<VotingActivitiesDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
    }
}
