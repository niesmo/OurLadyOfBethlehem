using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OLB.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    ApplicationType = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: false),
                    SentAtDate = table.Column<DateTimeOffset>(nullable: false),
                    SentById = table.Column<Guid>(nullable: false),
                    SentToEmailAddress = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTimeOffset>(nullable: false),
                    Token = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");
        }
    }
}
