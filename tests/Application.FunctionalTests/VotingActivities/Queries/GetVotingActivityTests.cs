using Voting.Application.Candidates.Commands.CreateCandidate;
using Voting.Application.Voters.Commands.CreateVoter;
using Voting.Application.Voters.Queries.GetVoters;
using Voting.Domain.Entities;

namespace Voting.Application.FunctionalTests.VotingActivitys.Queries;

using static Testing;

public class GetVotingActivityTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnAllVotingActivitys()
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
        await AddAsync(new VotingActivity
        {
            CandidateId = candidateId,
            VoterId = voterId
        });

        var query = new GetVotingActivities();

        var result = await SendAsync(query);

        result.Votes.Should().HaveCount(1);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetVotingActivities();

        var action = () => SendAsync(query);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
