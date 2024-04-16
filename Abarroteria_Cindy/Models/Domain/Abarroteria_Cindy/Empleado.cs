using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Empleado
    {
        public Empleado()
        {
            EncabezadoFacturas = new HashSet<EncabezadoFactura>();
        }

        public Guid IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string? Dni { get; set; }
        public string? Sexo { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid RolId { get; set; }

        public virtual Rol Rol { get; set; } = null!;
        public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
    }
}
