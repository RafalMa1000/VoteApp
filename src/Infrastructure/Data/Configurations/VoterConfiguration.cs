using Voting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Voting.Infrastructure.Data.Configurations;

public class VoterConfiguration : IEntityTypeConfiguration<Voter>
{
    public void Configure(EntityTypeBuilder<Voter> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
        builder
            .HasMany(t => t.VotingActivities)
            .WithOne(t => t.Voter)
            .HasForeignKey(t => t.VoterId)
            .HasPrincipalKey(t => t.Id);
    }
}
