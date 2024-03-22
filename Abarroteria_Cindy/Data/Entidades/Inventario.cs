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
        public Guid? Id_Proveedor { set; get; }
        public Proveedor? Proveedor { get; set; }
        public Guid? Id_Producto { set; get; }
        public Producto? Producto { get; set; }

    }
}
