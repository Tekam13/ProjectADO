using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_final.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categorie",
                table: "Films");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "categorie",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
