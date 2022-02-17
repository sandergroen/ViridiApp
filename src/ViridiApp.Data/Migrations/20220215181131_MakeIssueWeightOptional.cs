using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ViridiApp.Data.Migrations
{
    public partial class MakeIssueWeightOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Epic_EpicId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Milestone_MilestoneId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Board_BoardId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Milestone",
                table: "Milestone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Epic",
                table: "Epic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Board",
                table: "Board");

            migrationBuilder.RenameTable(
                name: "Milestone",
                newName: "Milestones");

            migrationBuilder.RenameTable(
                name: "Epic",
                newName: "Epics");

            migrationBuilder.RenameTable(
                name: "Board",
                newName: "Boards");

            migrationBuilder.AlterColumn<long>(
                name: "Weight",
                table: "Issues",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Milestones",
                table: "Milestones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Epics",
                table: "Epics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Iterations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iterations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Epics_EpicId",
                table: "Issues",
                column: "EpicId",
                principalTable: "Epics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Milestones_MilestoneId",
                table: "Issues",
                column: "MilestoneId",
                principalTable: "Milestones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Boards_BoardId",
                table: "Sections",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Epics_EpicId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Milestones_MilestoneId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Boards_BoardId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "Iterations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Milestones",
                table: "Milestones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Epics",
                table: "Epics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Milestones",
                newName: "Milestone");

            migrationBuilder.RenameTable(
                name: "Epics",
                newName: "Epic");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "Board");

            migrationBuilder.AlterColumn<long>(
                name: "Weight",
                table: "Issues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Milestone",
                table: "Milestone",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Epic",
                table: "Epic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Board",
                table: "Board",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Epic_EpicId",
                table: "Issues",
                column: "EpicId",
                principalTable: "Epic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Milestone_MilestoneId",
                table: "Issues",
                column: "MilestoneId",
                principalTable: "Milestone",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Board_BoardId",
                table: "Sections",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
