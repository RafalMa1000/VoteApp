using Voting.Application.Common.Interfaces;

namespace Voting.Application.Voters.Commands.CreateVoter;

public class CreateVoterCommandValidator : AbstractValidator<CreateVoterCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateVoterCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(20)
            .MustAsync(BeUniqueName)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return !await _context.Voters
            .AnyAsync(l => l.Name == name, cancellationToken);
    }
}
