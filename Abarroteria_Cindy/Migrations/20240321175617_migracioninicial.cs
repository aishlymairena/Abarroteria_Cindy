using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    public partial class migracioninicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgrupadoModulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "Varchar(255)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgrupadoModulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CAI",
                columns: table => new
                {
                    Id_Cai = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cai = table.Column<string>(type: "Varchar(37)", nullable: false),
                    Rango_Inicial = table.Column<int>(type: "int", nullable: false),
                    Rango_Final = table.Column<int>(type: "int", nullable: false),
                    Limite_Emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAI", x => x.Id_Cai);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id_Categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(60)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Apellido = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Direccion = table.Column<string>(type: "Varchar(255)", nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    DNI = table.Column<string>(type: "Varchar(13)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id_Proveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(60)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "Varchar(255)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id_Proveedor);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "Varchar(255)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(60)", nullable: false),
                    Metodo = table.Column<string>(type: "Varchar(25)", nullable: false),
                    Controller = table.Column<string>(type: "Varchar(25)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    AgrupadoModulosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modulo_AgrupadoModulos_AgrupadoModulosId",
                        column: x => x.AgrupadoModulosId,
                        principalTable: "AgrupadoModulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id_Producto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(60)", nullable: true),
                    Descripcion = table.Column<string>(type: "Varchar(255)", nullable: true),
                    Precio_Normal = table.Column<int>(type: "int", nullable: false),
                    Precio_Mayorista = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Categoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id_Producto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "Id_Categoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id_Empleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(50)", nullable: true),
                    Apellido = table.Column<string>(type: "Varchar(50)", nullable: true),
                    Direccion = table.Column<string>(type: "Varchar(255)", nullable: true),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    DNI = table.Column<string>(type: "Varchar(13)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id_Empleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModulosRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModulosRoles_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulosRoles_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id_Inventario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock_Actual = table.Column<int>(type: "int", nullable: false),
                    Stock_Minimo = table.Column<int>(type: "int", nullable: false),
                    Stock_Maximo = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Proveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Producto = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id_Inventario);
                    table.ForeignKey(
                        name: "FK_Inventario_Producto_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto");
                    table.ForeignKey(
                        name: "FK_Inventario_Proveedor_Id_Proveedor",
                        column: x => x.Id_Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id_Proveedor");
                });

            migrationBuilder.CreateTable(
                name: "Encabezado_Factura",
                columns: table => new
                {
                    Id_Encabezado_factura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha_Emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "Varchar(14)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Monto_Entregado = table.Column<int>(type: "int", nullable: false),
                    Cambio = table.Column<int>(type: "int", nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal (10,2)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Empleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Cai = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encabezado_Factura", x => x.Id_Encabezado_factura);
                    table.ForeignKey(
                        name: "FK_Encabezado_Factura_CAI_Id_Cai",
                        column: x => x.Id_Cai,
                        principalTable: "CAI",
                        principalColumn: "Id_Cai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encabezado_Factura_Cliente_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encabezado_Factura_Empleado_Id_Empleado",
                        column: x => x.Id_Empleado,
                        principalTable: "Empleado",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Factura",
                columns: table => new
                {
                    Id_Detalle_Factura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Total_Linea = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Encabezado_Factura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Producto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Factura", x => x.Id_Detalle_Factura);
                    table.ForeignKey(
                        name: "FK_Detalle_Factura_Encabezado_Factura_Id_Encabezado_Factura",
                        column: x => x.Id_Encabezado_Factura,
                        principalTable: "Encabezado_Factura",
                        principalColumn: "Id_Encabezado_factura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Factura_Producto_Id_Producto",
                        column: x => x.Id_Producto,
                        principalTable: "Producto",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Factura_Id_Encabezado_Factura",
                table: "Detalle_Factura",
                column: "Id_Encabezado_Factura");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Factura_Id_Producto",
                table: "Detalle_Factura",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_RolId",
                table: "Empleado",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Encabezado_Factura_Id_Cai",
                table: "Encabezado_Factura",
                column: "Id_Cai");

            migrationBuilder.CreateIndex(
                name: "IX_Encabezado_Factura_Id_Cliente",
                table: "Encabezado_Factura",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Encabezado_Factura_Id_Empleado",
                table: "Encabezado_Factura",
                column: "Id_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_Id_Producto",
                table: "Inventario",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_Id_Proveedor",
                table: "Inventario",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Modulo_AgrupadoModulosId",
                table: "Modulo",
                column: "AgrupadoModulosId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosRoles_ModuloId",
                table: "ModulosRoles",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulosRoles_RolId",
                table: "ModulosRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Id_Categoria",
                table: "Producto",
                column: "Id_Categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Factura");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "ModulosRoles");

            migrationBuilder.DropTable(
                name: "Encabezado_Factura");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "CAI");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "AgrupadoModulos");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
