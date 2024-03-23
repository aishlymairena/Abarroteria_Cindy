//using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class ProductoVm
    {
        public Guid Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio_Normal { get; set; }
        public int Precio_Mayorista { get; set; }
        public Guid Id_Categoria { set; get; }
        public CategoriaVm Categoria { get; set; }
    }
}
