using Voting.Application.Common.Interfaces;
using Voting.Application.Common.Security;

namespace Voting.Application.Candidates.Queries.GetCandidates
{
    [Authorize]
    public record GetCandidates : IRequest<CandidatesVm>;

    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidates, CandidatesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCandidatesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidatesVm> Handle(GetCandidates request, CancellationToken cancellationToken)
        {
            return new CandidatesVm
            {
                Candidates = await _context.Candidates
                    .AsNoTracking()
                    .ProjectTo<CandidateDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Id)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
