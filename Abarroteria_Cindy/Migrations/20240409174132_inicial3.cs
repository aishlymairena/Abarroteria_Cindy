using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalImp",
                table: "Pago",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalImp",
                table: "Pago");
        }
    }
}
