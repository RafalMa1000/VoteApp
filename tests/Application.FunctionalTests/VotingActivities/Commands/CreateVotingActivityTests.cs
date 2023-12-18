using Voting.Application.Candidates.Commands.CreateCandidate;
using Voting.Application.Common.Exceptions;
using Voting.Application.Voters.Commands.CreateVoter;
using Voting.Application.VotingActivities.Commands.CreateVotingActivity;

namespace Voting.Application.FunctionalTests.VotingActivitys.Commands;

using static Testing;

public class CreateVotingActivityTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateVotingActivityCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireUniqueVoter()
    {
        var voterId = await SendAsync(new CreateVoterCommand
        {
            Name = "Mrs V"
        });
        var candidateId = await SendAsync(new CreateCandidateCommand
        {
            Name = "Mrs C"
        });

        await SendAsync(new CreateVotingActivityCommand
        {
            CandidateId = candidateId,
            VoterId = voterId
        });

        var command = new CreateVotingActivityCommand
        {
            CandidateId = candidateId,
            VoterId = voterId
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateVotingActivity()
    {
        await RunAsDefaultUserAsync();
        
        var voterId = await SendAsync(new CreateVoterCommand
        {
            Name = "Mrs V"
        });
        var candidateId = await SendAsync(new CreateCandidateCommand
        {
            Name = "Mrs C"
        });
        var command = new CreateVotingActivityCommand
        {
            CandidateId = candidateId,
            VoterId = voterId
        };

        var count = await SendAsync(command);

        count.Should().BeGreaterThan(0);        
    }
}
