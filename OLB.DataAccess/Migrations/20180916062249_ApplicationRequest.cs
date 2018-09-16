using Microsoft.EntityFrameworkCore.Migrations;

namespace OLB.DataAccess.Migrations
{
    public partial class ApplicationRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "Applications",
                newName: "ApplicationRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationRequestId",
                table: "Applications",
                newName: "ApplicationId");
        }
    }
}
