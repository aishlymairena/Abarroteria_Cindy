using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class EncabezadoFactura
    {
        public EncabezadoFactura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public Guid IdEncabezadoFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NumeroFactura { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public int Total { get; set; }
        public int MontoEntregado { get; set; }
        public int Cambio { get; set; }
        public decimal Impuesto { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid IdEmpleado { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdCai { get; set; }

        public virtual Cai IdCaiNavigation { get; set; } = null!;
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
