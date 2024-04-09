using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Cliente
    {
        public Cliente()
        {
            EncabezadoFacturas = new HashSet<EncabezadoFactura>();
        }

        public Guid IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Dni { get; set; } = null!;
        public string? Sexo { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
    }
}
