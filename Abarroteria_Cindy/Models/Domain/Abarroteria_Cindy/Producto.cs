using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
            Inventarios = new HashSet<Inventario>();
        }

        public Guid IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int PrecioNormal { get; set; }
        public int PrecioMayorista { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
