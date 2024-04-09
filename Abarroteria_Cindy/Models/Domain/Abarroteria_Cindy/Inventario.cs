using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Inventario
    {
        public Guid IdInventario { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid? IdProveedor { get; set; }
        public Guid? IdProducto { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual Proveedor? IdProveedorNavigation { get; set; }
    }
}
