using Microsoft.EntityFrameworkCore.Migrations;

namespace _6._3.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopPosition",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "TopPosition1",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopPosition1",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "TopPosition",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
