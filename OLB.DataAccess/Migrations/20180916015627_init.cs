using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OLB.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    SubmissionDate = table.Column<DateTimeOffset>(nullable: false),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: false),
                    SentAtDate = table.Column<DateTimeOffset>(nullable: false),
                    SentById = table.Column<Guid>(nullable: false),
                    SentToEmailAddress = table.Column<string>(nullable: true),
                    Token = table.Column<Guid>(nullable: false),
                    ApplicationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
