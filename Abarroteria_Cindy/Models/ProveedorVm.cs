using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class ProveedorVm
    {
        public Guid Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Guid Id_Inventario { set; get; }
        public InventarioVm Inventario { get; set; }

    }
}
