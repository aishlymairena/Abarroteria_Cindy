using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class ModificacionLongitudDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Rol",
                type: "Varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedor",
                type: "Varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedor",
                type: "Varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Producto",
                type: "Varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Producto",
                type: "Varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Modulo",
                type: "Varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empelado",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empelado",
                type: "Varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Empelado",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cliente",
                type: "Varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Cliente",
                type: "Varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Cliente",
                type: "Varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categoria",
                type: "Varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "AgrupadoModulos",
                type: "Varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Rol",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Proveedor",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Proveedor",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Producto",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Producto",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Modulo",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cliente",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Cliente",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Cliente",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categoria",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "AgrupadoModulos",
                type: "Varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(255)");
        }
    }
}
