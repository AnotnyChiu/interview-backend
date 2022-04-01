using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DBAccess.Migrations
{
    public partial class ConvertSnakecase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interview_candidate_CandidateId",
                table: "interview");

            migrationBuilder.DropForeignKey(
                name: "FK_interview_interviewer_InterviewerId",
                table: "interview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interviewer",
                table: "interviewer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interview",
                table: "interview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_candidate",
                table: "candidate");

            migrationBuilder.RenameColumn(
                name: "InterviewerId",
                table: "interview",
                newName: "interviewer_id");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "interview",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_interview_InterviewerId",
                table: "interview",
                newName: "ix_interview_interviewer_id");

            migrationBuilder.RenameIndex(
                name: "IX_interview_CandidateId",
                table: "interview",
                newName: "ix_interview_candidate_id");

            migrationBuilder.AddColumn<bool>(
                name: "passed",
                table: "interview",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "interview",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "current_stage_id",
                table: "candidate",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "job_position_id",
                table: "candidate",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_interviewer",
                table: "interviewer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_interview",
                table: "interview",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_candidate",
                table: "candidate",
                column: "id");

            migrationBuilder.CreateTable(
                name: "interview_stages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_code = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    passed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interview_stages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    work_place = table.Column<string>(type: "text", nullable: true),
                    current_opened = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_positions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_candidate_current_stage_id",
                table: "candidate",
                column: "current_stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_job_position_id",
                table: "candidate",
                column: "job_position_id");

            migrationBuilder.AddForeignKey(
                name: "fk_candidate_interview_stages_current_stage_id",
                table: "candidate",
                column: "current_stage_id",
                principalTable: "interview_stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_candidate_job_positions_job_position_id",
                table: "candidate",
                column: "job_position_id",
                principalTable: "job_positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_interview_candidate_candidate_id",
                table: "interview",
                column: "candidate_id",
                principalTable: "candidate",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_interview_interviewer_interviewer_id",
                table: "interview",
                column: "interviewer_id",
                principalTable: "interviewer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_candidate_interview_stages_current_stage_id",
                table: "candidate");

            migrationBuilder.DropForeignKey(
                name: "fk_candidate_job_positions_job_position_id",
                table: "candidate");

            migrationBuilder.DropForeignKey(
                name: "fk_interview_candidate_candidate_id",
                table: "interview");

            migrationBuilder.DropForeignKey(
                name: "fk_interview_interviewer_interviewer_id",
                table: "interview");

            migrationBuilder.DropTable(
                name: "interview_stages");

            migrationBuilder.DropTable(
                name: "job_positions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_interviewer",
                table: "interviewer");

            migrationBuilder.DropPrimaryKey(
                name: "pk_interview",
                table: "interview");

            migrationBuilder.DropPrimaryKey(
                name: "pk_candidate",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "ix_candidate_current_stage_id",
                table: "candidate");

            migrationBuilder.DropIndex(
                name: "ix_candidate_job_position_id",
                table: "candidate");

            migrationBuilder.DropColumn(
                name: "passed",
                table: "interview");

            migrationBuilder.DropColumn(
                name: "status",
                table: "interview");

            migrationBuilder.DropColumn(
                name: "current_stage_id",
                table: "candidate");

            migrationBuilder.DropColumn(
                name: "job_position_id",
                table: "candidate");

            migrationBuilder.RenameColumn(
                name: "interviewer_id",
                table: "interview",
                newName: "InterviewerId");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "interview",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "ix_interview_interviewer_id",
                table: "interview",
                newName: "IX_interview_InterviewerId");

            migrationBuilder.RenameIndex(
                name: "ix_interview_candidate_id",
                table: "interview",
                newName: "IX_interview_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_interviewer",
                table: "interviewer",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_interview",
                table: "interview",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_candidate",
                table: "candidate",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_interview_candidate_CandidateId",
                table: "interview",
                column: "CandidateId",
                principalTable: "candidate",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_interview_interviewer_InterviewerId",
                table: "interview",
                column: "InterviewerId",
                principalTable: "interviewer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
