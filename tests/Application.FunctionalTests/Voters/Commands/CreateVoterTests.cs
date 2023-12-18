using Voting.Application.Common.Exceptions;
using Voting.Application.Voters.Commands.CreateVoter;
using Voting.Domain.Entities;

namespace Voting.Application.FunctionalTests.Voters.Commands;

using static Testing;

public class CreateVoterTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateVoterCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueName()
    {
        await SendAsync(new CreateVoterCommand
        {
            Name = "Mrs Y"
        });

        var command = new CreateVoterCommand
        {
            Name = "Mrs Y"
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateVoter()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateVoterCommand
        {
            Name = "Mr X"
        };

        var id = await SendAsync(command);

        var list = await FindAsync<Voter>(id);

        list.Should().NotBeNull();
        list!.Name.Should().Be(command.Name);
        list.CreatedBy.Should().Be(userId);
        list.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
