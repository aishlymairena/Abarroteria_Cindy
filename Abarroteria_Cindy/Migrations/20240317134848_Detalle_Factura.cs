using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class Detalle_Factura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Detalle_Factura_Id_Detalle_Factura",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_Id_Detalle_Factura",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Id_Detalle_Factura",
                table: "Producto");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Producto",
                table: "Detalle_Factura",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Factura_Id_Producto",
                table: "Detalle_Factura",
                column: "Id_Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Factura_Producto_Id_Producto",
                table: "Detalle_Factura",
                column: "Id_Producto",
                principalTable: "Producto",
                principalColumn: "Id_Producto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Factura_Producto_Id_Producto",
                table: "Detalle_Factura");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_Factura_Id_Producto",
                table: "Detalle_Factura");

            migrationBuilder.DropColumn(
                name: "Id_Producto",
                table: "Detalle_Factura");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Detalle_Factura",
                table: "Producto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Id_Detalle_Factura",
                table: "Producto",
                column: "Id_Detalle_Factura");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Detalle_Factura_Id_Detalle_Factura",
                table: "Producto",
                column: "Id_Detalle_Factura",
                principalTable: "Detalle_Factura",
                principalColumn: "Id_Detalle_Factura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
