using Voting.Application.Candidates.Queries.GetCandidates;
using Voting.Domain.Entities;

namespace Voting.Application.FunctionalTests.Candidates.Queries;

using static Testing;

public class GetCandidateTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnAllCandidates()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new Candidate
        {
            Name = "Candidate"
        });

        var query = new GetCandidates();

        var result = await SendAsync(query);

        result.Candidates.Should().HaveCount(1);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetCandidates();

        var action = () => SendAsync(query);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
