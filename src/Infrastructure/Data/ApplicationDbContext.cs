using System.Reflection;
using Voting.Application.Common.Interfaces;
using Voting.Domain.Entities;
using Voting.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Voting.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Voter> Voters => Set<Voter>();

    public DbSet<Candidate> Candidates => Set<Candidate>();

    public DbSet<VotingActivity> VotingActivities => Set<VotingActivity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
