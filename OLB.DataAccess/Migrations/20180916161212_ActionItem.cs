using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OLB.DataAccess.Migrations
{
    public partial class ActionItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionItems",
                columns: table => new
                {
                    ActionItemId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ActionItemUrgency = table.Column<string>(nullable: false),
                    ActionItemStatus = table.Column<string>(nullable: false),
                    RequestedBy = table.Column<Guid>(nullable: false),
                    RequestedAt = table.Column<DateTimeOffset>(nullable: false),
                    CompletedBy = table.Column<Guid>(nullable: false),
                    CompletedAt = table.Column<DateTimeOffset>(nullable: false),
                    AgeGroup = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItems", x => x.ActionItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionItems");
        }
    }
}
