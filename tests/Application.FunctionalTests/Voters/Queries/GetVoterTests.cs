using Voting.Application.Voters.Queries.GetVoters;
using Voting.Domain.Entities;

namespace Voting.Application.FunctionalTests.Voters.Queries;

using static Testing;

public class GetVoterTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnAllVoters()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new Voter
        {
            Name = "Voter"
        });

        var query = new GetVoters();

        var result = await SendAsync(query);

        result.Voters.Should().HaveCount(1);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetVoters();

        var action = () => SendAsync(query);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
