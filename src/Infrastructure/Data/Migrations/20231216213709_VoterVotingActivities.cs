using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voting.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class VoterVotingActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VotingActivities_VoterId",
                table: "VotingActivities");

            migrationBuilder.CreateIndex(
                name: "IX_VotingActivities_VoterId",
                table: "VotingActivities",
                column: "VoterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VotingActivities_VoterId",
                table: "VotingActivities");

            migrationBuilder.CreateIndex(
                name: "IX_VotingActivities_VoterId",
                table: "VotingActivities",
                column: "VoterId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);
        }
    }
}
