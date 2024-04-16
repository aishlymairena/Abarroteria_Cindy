using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class DetalleFactura
    {
        public Guid IdDetalleFactura { get; set; }
        public int Cantidad { get; set; }
        public int TotalLinea { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid IdEncabezadoFactura { get; set; }
        public Guid IdProducto { get; set; }

        public virtual EncabezadoFactura IdEncabezadoFacturaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
