using Voting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Voting.Infrastructure.Data.Configurations;

public class VotingActivityConfiguration : IEntityTypeConfiguration<VotingActivity>
{
    public void Configure(EntityTypeBuilder<VotingActivity> builder)
    {
        builder
            .HasIndex(i => i.VoterId)
            .IsUnique();            
        builder.Property(t => t.VoterId)
            .IsRequired();
        builder.Property(t => t.CandidateId)
            .IsRequired();

    }
}
