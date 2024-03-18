using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class Inventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proveedor_Inventario_Id_Inventario",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Proveedor_Id_Inventario",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Id_Inventario",
                table: "Proveedor");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Proveedor",
                table: "Inventario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_Id_Proveedor",
                table: "Inventario",
                column: "Id_Proveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_Proveedor_Id_Proveedor",
                table: "Inventario",
                column: "Id_Proveedor",
                principalTable: "Proveedor",
                principalColumn: "Id_Proveedor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_Proveedor_Id_Proveedor",
                table: "Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Inventario_Id_Proveedor",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Id_Proveedor",
                table: "Inventario");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Inventario",
                table: "Proveedor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Id_Inventario",
                table: "Proveedor",
                column: "Id_Inventario");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedor_Inventario_Id_Inventario",
                table: "Proveedor",
                column: "Id_Inventario",
                principalTable: "Inventario",
                principalColumn: "Id_Inventario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
