using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatBeauty.Migrations
{
    public partial class m3345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Salons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Salons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Salons");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Salons");
        }
    }
}
