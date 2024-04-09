using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public Guid IdProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public int Telefono { get; set; }
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
