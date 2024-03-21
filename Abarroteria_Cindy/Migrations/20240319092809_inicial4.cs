using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empelado_Rol_RolId",
                table: "Empelado");

            migrationBuilder.DropForeignKey(
                name: "FK_Encabezado_Factura_Empelado_Id_Empleado",
                table: "Encabezado_Factura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empelado",
                table: "Empelado");

            migrationBuilder.RenameTable(
                name: "Empelado",
                newName: "Empleado");

            migrationBuilder.RenameIndex(
                name: "IX_Empelado_RolId",
                table: "Empleado",
                newName: "IX_Empleado_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado",
                column: "Id_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encabezado_Factura_Empleado_Id_Empleado",
                table: "Encabezado_Factura",
                column: "Id_Empleado",
                principalTable: "Empleado",
                principalColumn: "Id_Empleado",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Encabezado_Factura_Empleado_Id_Empleado",
                table: "Encabezado_Factura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado");

            migrationBuilder.RenameTable(
                name: "Empleado",
                newName: "Empelado");

            migrationBuilder.RenameIndex(
                name: "IX_Empleado_RolId",
                table: "Empelado",
                newName: "IX_Empelado_RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empelado",
                table: "Empelado",
                column: "Id_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Empelado_Rol_RolId",
                table: "Empelado",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encabezado_Factura_Empelado_Id_Empleado",
                table: "Encabezado_Factura",
                column: "Id_Empleado",
                principalTable: "Empelado",
                principalColumn: "Id_Empleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
