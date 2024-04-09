using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Abarroteria_CindyContext : DbContext
    {
        public Abarroteria_CindyContext()
        {
        }

        public Abarroteria_CindyContext(DbContextOptions<Abarroteria_CindyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgrupadoModulo> AgrupadoModulos { get; set; } = null!;
        public virtual DbSet<Cai> Cais { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<EncabezadoFactura> EncabezadoFacturas { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Modulo> Modulos { get; set; } = null!;
        public virtual DbSet<ModulosRole> ModulosRoles { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DPI ;Database=Abarroteria_Cindy;Persist Security Info = True; User ID = sa; Password=1234;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgrupadoModulo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cai>(entity =>
            {
                entity.HasKey(e => e.IdCai);

                entity.ToTable("CAI");

                entity.Property(e => e.IdCai)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Cai");

                entity.Property(e => e.Cai1)
                    .HasMaxLength(37)
                    .IsUnicode(false)
                    .HasColumnName("Cai");

                entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");

                entity.Property(e => e.LimiteEmision).HasColumnName("Limite_Emision");

                entity.Property(e => e.RangoFinal).HasColumnName("Rango_Final");

                entity.Property(e => e.RangoInicial).HasColumnName("Rango_Inicial");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.IdCategoria)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura);

                entity.ToTable("Detalle_Factura");

                entity.HasIndex(e => e.IdEncabezadoFactura, "IX_Detalle_Factura_Id_Encabezado_Factura");

                entity.HasIndex(e => e.IdProducto, "IX_Detalle_Factura_Id_Producto");

                entity.Property(e => e.IdDetalleFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Detalle_Factura");

                entity.Property(e => e.IdEncabezadoFactura).HasColumnName("Id_Encabezado_Factura");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.Property(e => e.TotalLinea).HasColumnName("Total_Linea");

                entity.HasOne(d => d.IdEncabezadoFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdEncabezadoFactura);

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdProducto);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("Empleado");

                entity.HasIndex(e => e.RolId, "IX_Empleado_RolId");

                entity.Property(e => e.IdEmpleado)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Empleado");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.RolId);
            });

            modelBuilder.Entity<EncabezadoFactura>(entity =>
            {
                entity.HasKey(e => e.IdEncabezadoFactura);

                entity.ToTable("Encabezado_Factura");

                entity.HasIndex(e => e.IdCai, "IX_Encabezado_Factura_Id_Cai");

                entity.HasIndex(e => e.IdCliente, "IX_Encabezado_Factura_Id_Cliente");

                entity.HasIndex(e => e.IdEmpleado, "IX_Encabezado_Factura_Id_Empleado");

                entity.Property(e => e.IdEncabezadoFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Encabezado_factura");

                entity.Property(e => e.Dni)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("DNI");

                entity.Property(e => e.FechaEmision).HasColumnName("Fecha_Emision");

                entity.Property(e => e.IdCai).HasColumnName("Id_Cai");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");

                entity.Property(e => e.Impuesto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MontoEntregado).HasColumnName("Monto_Entregado");

                entity.HasOne(d => d.IdCaiNavigation)
                    .WithMany(p => p.EncabezadoFacturas)
                    .HasForeignKey(d => d.IdCai);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.EncabezadoFacturas)
                    .HasForeignKey(d => d.IdCliente);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EncabezadoFacturas)
                    .HasForeignKey(d => d.IdEmpleado);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario);

                entity.ToTable("Inventario");

                entity.HasIndex(e => e.IdProducto, "IX_Inventario_Id_Producto");

                entity.HasIndex(e => e.IdProveedor, "IX_Inventario_Id_Proveedor");

                entity.Property(e => e.IdInventario)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Inventario");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");

                entity.Property(e => e.StockActual).HasColumnName("Stock_Actual");

                entity.Property(e => e.StockMaximo).HasColumnName("Stock_Maximo");

                entity.Property(e => e.StockMinimo).HasColumnName("Stock_Minimo");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdProducto);

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdProveedor);
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Modulo");

                entity.HasIndex(e => e.AgrupadoModulosId, "IX_Modulo_AgrupadoModulosId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Controller)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Metodo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.AgrupadoModulos)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.AgrupadoModulosId);
            });

            modelBuilder.Entity<ModulosRole>(entity =>
            {
                entity.HasIndex(e => e.ModuloId, "IX_ModulosRoles_ModuloId");

                entity.HasIndex(e => e.RolId, "IX_ModulosRoles_RolId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.ModulosRoles)
                    .HasForeignKey(d => d.ModuloId);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.ModulosRoles)
                    .HasForeignKey(d => d.RolId);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("Producto");

                entity.HasIndex(e => e.IdCategoria, "IX_Producto_Id_Categoria");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioMayorista).HasColumnName("Precio_Mayorista");

                entity.Property(e => e.PrecioNormal).HasColumnName("Precio_Normal");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("Proveedor");

                entity.Property(e => e.IdProveedor)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Proveedor");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
