using Abarroteria_Cindy.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using static Abarroteria_Cindy.Data.EntityConfig;

namespace Abarroteria_Cindy.Data
{
    public class AbarroteriaBdContext : DbContext
    {
        public AbarroteriaBdContext(DbContextOptions<AbarroteriaBdContext> options) : base(options) { }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<AgrupadoModulos> AgrupadoModulos { get; set; }
        public DbSet<ModulosRoles> ModulosRoles { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Encabezado_Factura> Encabezado_Factura { get; set; }
        public DbSet<CAI> CAI { get; set; }
       
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Detalle_Factura> Detalle_Factura { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pago> Pago { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAI>().HasKey(c => c.Id_Cai);

            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new ModuloConfig());
            modelBuilder.ApplyConfiguration(new AgrupadoModulosConfig());
            modelBuilder.ApplyConfiguration(new ModulosRolesConfig());
            modelBuilder.ApplyConfiguration(new EmpleadosConfig());
            modelBuilder.ApplyConfiguration(new EncabezadoConfig());
            modelBuilder.ApplyConfiguration(new CAIConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new DetalleConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new InventarioConfig());
            modelBuilder.ApplyConfiguration(new ProveedorConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new PagoConfig());
        }
    }
}
