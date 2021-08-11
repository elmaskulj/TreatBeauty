﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatBeauty.Migrations
{
    public partial class m34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BaseUserRoles_BaseUserId",
                table: "BaseUserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_BaseUserRoles_BaseUserId",
                table: "BaseUserRoles",
                column: "BaseUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BaseUserRoles_BaseUserId",
                table: "BaseUserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_BaseUserRoles_BaseUserId",
                table: "BaseUserRoles",
                column: "BaseUserId");
        }
    }
}
