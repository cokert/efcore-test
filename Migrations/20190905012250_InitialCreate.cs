using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace efcore_test.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestTables",
                columns: table => new
                {
                    KeyColumn1 = table.Column<Guid>(nullable: false),
                    OtherColumn2 = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTables", x => x.KeyColumn1);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTables");
        }
    }
}
