using Abarroteria_Cindy.Data.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Abarroteria_Cindy.Data
{
    public class EntityConfig
    {
        public class RolConfig : IEntityTypeConfiguration<Rol>
        {
            public void Configure(EntityTypeBuilder<Rol> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(s => s.Descripcion).HasColumnType("Varchar(255)").HasColumnName("Descripcion");
                builder.HasMany(a => a.ModulosRoles).WithOne(a => a.Rol).HasForeignKey(c => c.RolId);
                builder.HasMany(a => a.Empleados).WithOne(a => a.Rol).HasForeignKey(c => c.RolId);
            }

        }
        public class ModuloConfig : IEntityTypeConfiguration<Modulo>
        {
            public void Configure(EntityTypeBuilder<Modulo> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(s => s.Nombre).HasColumnType("Varchar(60)").HasColumnName("Nombre");
                builder.Property(s => s.Metodo).HasColumnType("Varchar(25)").HasColumnName("Metodo");
                builder.Property(s => s.Controller).HasColumnType("Varchar(25)").HasColumnName("Controller");
                builder.HasMany(a => a.ModulosRoles).WithOne(a => a.Modulo).HasForeignKey(c => c.ModuloId);
            }

        }
        public class ModulosRolesConfig : IEntityTypeConfiguration<ModulosRoles>
        {
            public void Configure(EntityTypeBuilder<ModulosRoles> builder)
            {
                builder.HasKey(x => x.Id);

            }

        }
        public class AgrupadoModulosConfig : IEntityTypeConfiguration<AgrupadoModulos>
        {
            public void Configure(EntityTypeBuilder<AgrupadoModulos> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(s => s.Descripcion).HasColumnType("Varchar(255)").HasColumnName("Descripcion");
                builder.HasMany(a => a.Modulos).WithOne(a => a.AgrupadoModulos).HasForeignKey(c => c.AgrupadoModulosId);
            }

        }
        public class EmpleadosConfig : IEntityTypeConfiguration<Empleado>
        {
            public void Configure(EntityTypeBuilder<Empleado> builder)
            {
                builder.HasKey(x => x.Id_Empleado);
                builder.Property(s => s.Nombre).HasColumnType("Varchar(50)").HasColumnName("Nombre");
                builder.Property(s => s.Apellido).HasColumnType("Varchar(50)").HasColumnName("Apellido");
                builder.Property(s => s.Direccion).HasColumnType("Varchar(255)").HasColumnName("Direccion");
                builder.Property(s => s.DNI).HasColumnType("Varchar(13)").HasColumnName("DNI");
                builder.HasMany(a => a.Encabezados).WithOne(a => a.Empleado).HasForeignKey(c => c.Id_Empleado);
            }

        }
        public class CAIConfig : IEntityTypeConfiguration<CAI>
        {
            public void Configure(EntityTypeBuilder<CAI> builder)
            {
                builder.HasKey(x => x.Id_Cai);
                builder.Property(s => s.Cai).HasColumnType("Varchar(37)").HasColumnName("Cai");
                builder.HasMany(a => a.Encabezados).WithOne(a => a.CAI).HasForeignKey(c => c.Id_Cai);
            }

        }
        public class EncabezadoConfig : IEntityTypeConfiguration<Encabezado_Factura>
        {
            public void Configure(EntityTypeBuilder<Encabezado_Factura> builder)
            {
                builder.HasKey(x => x.Id_Encabezado_factura);
                builder.Property(s => s.Impuesto).HasColumnType("decimal (10,2)").HasColumnName("Impuesto");
                builder.Property(s => s.RTN).HasColumnType("Varchar(14)").HasColumnName("DNI");
                builder.HasMany(a => a.Detalles).WithOne(a => a.Encabezado_Factura).HasForeignKey(c => c.Id_Encabezado_Factura);
            }

        }
        public class ClienteConfig : IEntityTypeConfiguration<Cliente>
        {
            public void Configure(EntityTypeBuilder<Cliente> builder)
            {
                builder.HasKey(x => x.Id_Cliente);
                builder.Property(s => s.Nombre).HasColumnType("Varchar(50)").HasColumnName("Nombre");
                builder.Property(s => s.Apellido).HasColumnType("Varchar(50)").HasColumnName("Apellido");
                builder.Property(s => s.Direccion).HasColumnType("Varchar(255)").HasColumnName("Direccion");
                builder.Property(s => s.DNI).HasColumnType("Varchar(13)").HasColumnName("DNI");
                builder.HasMany(a => a.Encabezados).WithOne(a => a.Cliente).HasForeignKey(c => c.Id_Cliente);
            }

        }
        public class DetalleConfig : IEntityTypeConfiguration<Detalle_Factura>
        {
            public void Configure(EntityTypeBuilder<Detalle_Factura> builder)
            {
                builder.HasKey(x => x.Id_Detalle_Factura);

            }

        }
        public class ProductoConfig : IEntityTypeConfiguration<Producto>
        {
            public void Configure(EntityTypeBuilder<Producto> builder)
            {
                builder.HasKey(x => x.Id_Producto);
                builder.Property(s => s.Nombre).HasColumnType("Varchar(60)").HasColumnName("Nombre");
                builder.Property(s => s.Descripcion).HasColumnType("Varchar(255)").HasColumnName("Descripcion");
                builder.HasMany(a => a.Detalles).WithOne(a => a.Producto).HasForeignKey(c => c.Id_Producto);
                builder.HasMany(a => a.Inventarios).WithOne(a => a.Producto).HasForeignKey(c => c.Id_Producto).OnDelete(DeleteBehavior.NoAction); ; 
            }

        }
        public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
        {
            public void Configure(EntityTypeBuilder<Categoria> builder)
            {
                builder.HasKey(x => x.Id_Categoria);
                builder.Property(s => s.Nombre).HasColumnType("Varchar(60)").HasColumnName("Nombre");
                builder.HasMany(a => a.Productos).WithOne(a => a.Categoria).HasForeignKey(c => c.Id_Categoria);
            }

        }
        public class InventarioConfig : IEntityTypeConfiguration<Inventario>
        {
            public void Configure(EntityTypeBuilder<Inventario> builder)
            {
                builder.HasKey(x => x.Id_Inventario);
               
            }

        }
        public class ProveedorConfig : IEntityTypeConfiguration<Proveedor>
        {
            public void Configure(EntityTypeBuilder<Proveedor> builder)
            {
                builder.HasKey(x => x.Id_Proveedor);
                builder.HasMany(a => a.Inventarios).WithOne(a => a.Proveedor).HasForeignKey(c => c.Id_Proveedor);
                builder.Property(s => s.Nombre).HasColumnType("Varchar(60)").HasColumnName("Nombre");
                builder.Property(s => s.Direccion).HasColumnType("Varchar(255)").HasColumnName("Direccion");
            }

        }
    }
}
