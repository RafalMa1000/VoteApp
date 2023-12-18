using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voting.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class VotingActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotingActivity_Candidates_CandidateId",
                table: "VotingActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_VotingActivity_Voters_VoterId",
                table: "VotingActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VotingActivity",
                table: "VotingActivity");

            migrationBuilder.RenameTable(
                name: "VotingActivity",
                newName: "VotingActivities");

            migrationBuilder.RenameIndex(
                name: "IX_VotingActivity_VoterId",
                table: "VotingActivities",
                newName: "IX_VotingActivities_VoterId");

            migrationBuilder.RenameIndex(
                name: "IX_VotingActivity_CandidateId",
                table: "VotingActivities",
                newName: "IX_VotingActivities_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VotingActivities",
                table: "VotingActivities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VotingActivities_Candidates_CandidateId",
                table: "VotingActivities",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotingActivities_Voters_VoterId",
                table: "VotingActivities",
                column: "VoterId",
                principalTable: "Voters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotingActivities_Candidates_CandidateId",
                table: "VotingActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_VotingActivities_Voters_VoterId",
                table: "VotingActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VotingActivities",
                table: "VotingActivities");

            migrationBuilder.RenameTable(
                name: "VotingActivities",
                newName: "VotingActivity");

            migrationBuilder.RenameIndex(
                name: "IX_VotingActivities_VoterId",
                table: "VotingActivity",
                newName: "IX_VotingActivity_VoterId");

            migrationBuilder.RenameIndex(
                name: "IX_VotingActivities_CandidateId",
                table: "VotingActivity",
                newName: "IX_VotingActivity_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VotingActivity",
                table: "VotingActivity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VotingActivity_Candidates_CandidateId",
                table: "VotingActivity",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotingActivity_Voters_VoterId",
                table: "VotingActivity",
                column: "VoterId",
                principalTable: "Voters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
