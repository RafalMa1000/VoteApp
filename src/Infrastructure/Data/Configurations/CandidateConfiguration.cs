using Voting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Voting.Infrastructure.Data.Configurations;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
        builder
            .HasMany(t => t.VotingActivities)
            .WithOne(t => t.Candidate)
            .HasForeignKey(t => t.CandidateId)
            .HasPrincipalKey(t => t.Id);
    }
}
