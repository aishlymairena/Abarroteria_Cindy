using System;

namespace Abarroteria_Cindy.Models
{
    public class InventarioVm
    {
        public Guid Id_Inventario { get; set; }
        public int Stock_Actual { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
        public Guid? Id_Proveedor { set; get; }
        public ProveedorVm? Proveedor { get; set; }
        public Guid? Id_Producto { set; get; }
        public ProductoVm? Producto { get; set; }

        public bool Validacion()
        {
            if (Stock_Actual < 0)
            {
                return false;
            }
            if (Stock_Minimo < 0)
            {
                return false;
            }
            if (Stock_Maximo <= 0)
            {
                return false;
            }
            if (Id_Proveedor == Guid.Empty)
            {
                return false;
            }
            if (Id_Producto == null || Id_Producto == Guid.Empty)
            {
                return false;
            }
            return true;
        }
    }
}

