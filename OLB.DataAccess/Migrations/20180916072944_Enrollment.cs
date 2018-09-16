using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OLB.DataAccess.Migrations
{
    public partial class Enrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentParent_Parents_ParentId",
                table: "StudentParent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParent_Students_StudentId",
                table: "StudentParent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentParent",
                table: "StudentParent");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "ApplicationType",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SentAtDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SentById",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SentToEmailAddress",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "StudentParent",
                newName: "StudentParents");

            migrationBuilder.RenameColumn(
                name: "ApplicationRequestId",
                table: "Applications",
                newName: "ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentParent_ParentId",
                table: "StudentParents",
                newName: "IX_StudentParents_ParentId");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgeGroup",
                table: "Classrooms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ApplicationFeePaid",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApplicationFeeWaived",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentParents",
                table: "StudentParents",
                columns: new[] { "StudentId", "ParentId" });

            migrationBuilder.CreateTable(
                name: "ApplicationRequests",
                columns: table => new
                {
                    ApplicationRequestId = table.Column<Guid>(nullable: false),
                    SubmissionDate = table.Column<DateTimeOffset>(nullable: false),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: false),
                    SentAtDate = table.Column<DateTimeOffset>(nullable: false),
                    SentById = table.Column<Guid>(nullable: false),
                    SentToEmailAddress = table.Column<string>(nullable: true),
                    Token = table.Column<Guid>(nullable: false),
                    ApplicationRequestType = table.Column<int>(nullable: false),
                    ApplicationRequestStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRequests", x => x.ApplicationRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(nullable: false),
                    Day = table.Column<string>(nullable: false),
                    EnrollmentStatus = table.Column<string>(nullable: false),
                    IsFlexible = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentApplications",
                columns: table => new
                {
                    ParentId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentApplications", x => new { x.ParentId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_ParentApplications_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentApplications_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationId",
                table: "Students",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ApplicationId",
                table: "Parents",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ApplicationId",
                table: "Enrollments",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentApplications_ApplicationId",
                table: "ParentApplications",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Applications_ApplicationId",
                table: "Parents",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Parents_ParentId",
                table: "StudentParents",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Students_StudentId",
                table: "StudentParents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Applications_ApplicationId",
                table: "Students",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Applications_ApplicationId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Parents_ParentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Students_StudentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Applications_ApplicationId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ApplicationRequests");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "ParentApplications");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Parents_ApplicationId",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentParents",
                table: "StudentParents");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "ApplicationFeePaid",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationFeeWaived",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "StudentParents",
                newName: "StudentParent");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "Applications",
                newName: "ApplicationRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentParents_ParentId",
                table: "StudentParent",
                newName: "IX_StudentParent_ParentId");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Classrooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationType",
                table: "Applications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpirationDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "SentAtDate",
                table: "Applications",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "SentById",
                table: "Applications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SentToEmailAddress",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Applications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Token",
                table: "Applications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentParent",
                table: "StudentParent",
                columns: new[] { "StudentId", "ParentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParent_Parents_ParentId",
                table: "StudentParent",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParent_Students_StudentId",
                table: "StudentParent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
