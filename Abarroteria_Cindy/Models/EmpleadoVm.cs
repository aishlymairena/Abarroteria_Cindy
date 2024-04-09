using Abarroteria_Cindy.Data.Entidades;
using System.Text.RegularExpressions;

namespace Abarroteria_Cindy.Models
{
    public class EmpleadoVm
    {
        public Guid Id_Empleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string? DNI { get; set; }
        public string? Sexo { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? Contraseña2 { get; set; }
        public RolVm? Rol { get; set; }
        public Guid RolId { set; get; }
        public List<AgrupadoVm> Menu { get; set; }
        public bool Validacion()
        {
            // Verifica si alguno de los campos requeridos está vacío
            if (string.IsNullOrEmpty(Nombre) ||
             string.IsNullOrEmpty(Apellido) ||
     string.IsNullOrEmpty(Direccion) ||
     string.IsNullOrEmpty(Sexo) ||
     string.IsNullOrEmpty(Correo) ||
     string.IsNullOrEmpty(Contraseña2) ||
     string.IsNullOrEmpty(Contraseña) ||
     string.IsNullOrEmpty(DNI) ||
     Fecha_Nacimiento == null ||
     Telefono == 0)
            {
                return false;
            }
            return true;


        }

    }
}
