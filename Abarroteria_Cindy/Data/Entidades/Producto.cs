namespace Abarroteria_Cindy.Data.Entidades
{
    public class Producto
    {
        public Guid Id_Producto { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set; }
        public int Precio_Normal { get; set; }
        public int Precio_Mayorista { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid Id_Categoria { set; get; }
        public Categoria Categoria { get; set; }
        public Guid Id_Inventario { set; get; }
        public Inventario Inventario { get; set; }

        public ICollection<Detalle_Factura> Detalles { get; set; }
        public Producto()
        {
            Detalles = new HashSet<Detalle_Factura>();
        }
    }
}
