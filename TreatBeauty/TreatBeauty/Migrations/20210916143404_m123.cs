using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatBeauty.Migrations
{
    public partial class m123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerServiceRecommend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServiceRecommend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerServiceRecommend_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerServiceRecommend_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceRecommend_CustomerId",
                table: "CustomerServiceRecommend",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServiceRecommend_ServiceId",
                table: "CustomerServiceRecommend",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerServiceRecommend");
        }
    }
}
