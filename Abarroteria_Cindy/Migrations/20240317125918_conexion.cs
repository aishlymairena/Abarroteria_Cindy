using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class conexion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Empelado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Empelado",
                type: "Varchar(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(13)");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Empelado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Contraseña",
                table: "Empelado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Sexo",
                table: "Empelado",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Empelado",
                type: "Varchar(13)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(13)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Empelado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contraseña",
                table: "Empelado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Empelado",
                type: "Varchar(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Varchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Sexo",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
