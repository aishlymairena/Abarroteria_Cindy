﻿// <auto-generated />
using System;
using Abarroteria_Cindy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Abarroteria_Cindy.Migrations
{
    [DbContext(typeof(AbarroteriaBdContext))]
    [Migration("20240317161448_ModificacionLongitudDatos")]
    partial class ModificacionLongitudDatos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.AgrupadoModulos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AgrupadoModulos");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.CAI", b =>
                {
                    b.Property<Guid>("Id_Cai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cai")
                        .IsRequired()
                        .HasColumnType("Varchar(37)")
                        .HasColumnName("Cai");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Limite_Emision")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rango_Final")
                        .HasColumnType("int");

                    b.Property<int>("Rango_Inicial")
                        .HasColumnType("int");

                    b.HasKey("Id_Cai");

                    b.ToTable("CAI");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Categoria", b =>
                {
                    b.Property<Guid>("Id_Categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("Varchar(60)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id_Categoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Cliente", b =>
                {
                    b.Property<Guid>("Id_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Apellido");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("Varchar(13)")
                        .HasColumnName("DNI");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Direccion");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id_Cliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Detalle_Factura", b =>
                {
                    b.Property<Guid>("Id_Detalle_Factura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("Id_Encabezado_Factura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Producto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Total_Linea")
                        .HasColumnType("int");

                    b.HasKey("Id_Detalle_Factura");

                    b.HasIndex("Id_Encabezado_Factura");

                    b.HasIndex("Id_Producto");

                    b.ToTable("Detalle_Factura");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Empleado", b =>
                {
                    b.Property<Guid>("Id_Empleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Apellido");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DNI")
                        .HasColumnType("Varchar(13)")
                        .HasColumnName("DNI");

                    b.Property<string>("Direccion")
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Direccion");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id_Empleado");

                    b.HasIndex("RolId");

                    b.ToTable("Empelado");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Encabezado_Factura", b =>
                {
                    b.Property<Guid>("Id_Encabezado_factura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cambio")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha_Emision")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Cai")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Cliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Empleado")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal (10,2)")
                        .HasColumnName("Impuesto");

                    b.Property<int>("Monto_Entregado")
                        .HasColumnType("int");

                    b.Property<string>("RTN")
                        .IsRequired()
                        .HasColumnType("Varchar(14)")
                        .HasColumnName("DNI");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id_Encabezado_factura");

                    b.HasIndex("Id_Cai");

                    b.HasIndex("Id_Cliente");

                    b.HasIndex("Id_Empleado");

                    b.ToTable("Encabezado_Factura");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Inventario", b =>
                {
                    b.Property<Guid>("Id_Inventario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("Id_Proveedor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stock_Actual")
                        .HasColumnType("int");

                    b.Property<int>("Stock_Maximo")
                        .HasColumnType("int");

                    b.Property<int>("Stock_Minimo")
                        .HasColumnType("int");

                    b.HasKey("Id_Inventario");

                    b.HasIndex("Id_Proveedor");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Modulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgrupadoModulosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasColumnType("Varchar(25)")
                        .HasColumnName("Controller");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Metodo")
                        .IsRequired()
                        .HasColumnType("Varchar(25)")
                        .HasColumnName("Metodo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("Varchar(60)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("AgrupadoModulosId");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.ModulosRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModuloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.HasIndex("RolId");

                    b.ToTable("ModulosRoles");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Producto", b =>
                {
                    b.Property<Guid>("Id_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Apellido");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<Guid>("Id_Categoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Inventario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("Varchar(60)")
                        .HasColumnName("Nombre");

                    b.Property<int>("Precio_Mayorista")
                        .HasColumnType("int");

                    b.Property<int>("Precio_Normal")
                        .HasColumnType("int");

                    b.HasKey("Id_Producto");

                    b.HasIndex("Id_Categoria");

                    b.HasIndex("Id_Inventario");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Proveedor", b =>
                {
                    b.Property<Guid>("Id_Proveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Direccion");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("Varchar(60)")
                        .HasColumnName("Nombre");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id_Proveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasColumnName("Descripcion");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Detalle_Factura", b =>
                {
                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Encabezado_Factura", "Encabezado_Factura")
                        .WithMany("Detalles")
                        .HasForeignKey("Id_Encabezado_Factura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Producto", "Producto")
                        .WithMany("Detalles")
                        .HasForeignKey("Id_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encabezado_Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Empleado", b =>
                {
                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Rol", "Rol")
                        .WithMany("Empleados")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Encabezado_Factura", b =>
                {
                    b.HasOne("Abarroteria_Cindy.Data.Entidades.CAI", "CAI")
                        .WithMany("Encabezados")
                        .HasForeignKey("Id_Cai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Cliente", "Cliente")
                        .WithMany("Encabezados")
                        .HasForeignKey("Id_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Empleado", "Empleado")
                        .WithMany("Encabezados")
                        .HasForeignKey("Id_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CAI");

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Inventario", b =>
                {
                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Proveedor", "Proveedor")
                        .WithMany("Inventarios")
                        .HasForeignKey("Id_Proveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Modulo", b =>
                {
                    b.HasOne("Abarroteria_Cindy.Data.Entidades.AgrupadoModulos", "AgrupadoModulos")
                        .WithMany("Modulos")
                        .HasForeignKey("AgrupadoModulosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgrupadoModulos");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.ModulosRoles", b =>
                {
                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Modulo", "Modulo")
                        .WithMany("ModulosRoles")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Rol", "Rol")
                        .WithMany("ModulosRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Producto", b =>
                {
                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("Id_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Abarroteria_Cindy.Data.Entidades.Inventario", "Inventario")
                        .WithMany("Productos")
                        .HasForeignKey("Id_Inventario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Inventario");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.AgrupadoModulos", b =>
                {
                    b.Navigation("Modulos");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.CAI", b =>
                {
                    b.Navigation("Encabezados");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Cliente", b =>
                {
                    b.Navigation("Encabezados");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Empleado", b =>
                {
                    b.Navigation("Encabezados");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Encabezado_Factura", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Inventario", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Modulo", b =>
                {
                    b.Navigation("ModulosRoles");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Producto", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Proveedor", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("Abarroteria_Cindy.Data.Entidades.Rol", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("ModulosRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
