namespace Abarroteria_Cindy.Data.Entidades
{
    public class Inventario
    {
        public Guid Id_Inventario { get; set; }
        public int Stock_Actual { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public ICollection<Proveedor> Proveedores { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public Inventario()
        {
            Proveedores = new HashSet<Proveedor>();
            Productos = new HashSet<Producto>();
        }
    }
}
