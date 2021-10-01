using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWWW.DataAccess.Migrations
{
    public partial class DescAddedToMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MenuItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MenuItem");
        }
    }
}
