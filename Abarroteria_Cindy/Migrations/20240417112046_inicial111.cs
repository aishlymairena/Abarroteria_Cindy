using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class inicial111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cambio",
                table: "Encabezado_Factura");

            migrationBuilder.DropColumn(
                name: "Impuesto",
                table: "Encabezado_Factura");

            migrationBuilder.DropColumn(
                name: "Monto_Entregado",
                table: "Encabezado_Factura");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Encabezado_Factura");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroFactura",
                table: "Encabezado_Factura",
                type: "Varchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroFactura",
                table: "Encabezado_Factura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(14)");

            migrationBuilder.AddColumn<int>(
                name: "Cambio",
                table: "Encabezado_Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Impuesto",
                table: "Encabezado_Factura",
                type: "decimal (10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Monto_Entregado",
                table: "Encabezado_Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Encabezado_Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
