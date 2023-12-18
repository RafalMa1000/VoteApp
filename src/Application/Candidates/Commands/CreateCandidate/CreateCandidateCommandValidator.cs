using Voting.Application.Common.Interfaces;

namespace Voting.Application.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCandidateCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)            
            .MaximumLength(20)
            .NotEmpty()
            .MustAsync(BeUniqueName)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return !await _context.Candidates
            .AnyAsync(l => l.Name == name, cancellationToken);
    }
}
