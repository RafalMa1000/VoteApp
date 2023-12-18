using Voting.Application.Common.Exceptions;
using Voting.Application.Candidates.Commands.CreateCandidate;
using Voting.Domain.Entities;

namespace Voting.Application.FunctionalTests.Candidates.Commands;

using static Testing;

public class CreateCandidateTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateCandidateCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueName()
    {
        await SendAsync(new CreateCandidateCommand
        {
            Name = "Mrs Y"
        });

        var command = new CreateCandidateCommand
        {
            Name = "Mrs Y"
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateCandidate()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateCandidateCommand
        {
            Name = "Mr X"
        };

        var id = await SendAsync(command);

        var list = await FindAsync<Candidate>(id);

        list.Should().NotBeNull();
        list!.Name.Should().Be(command.Name);
        list.CreatedBy.Should().Be(userId);
        list.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
