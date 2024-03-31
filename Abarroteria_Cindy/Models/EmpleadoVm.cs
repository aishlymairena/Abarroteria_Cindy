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
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string? DNI { get; set; }
        public string? Sexo { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? Contraseña2 { get; set; }
        public RolVm? Rol { get; set; }
        public Guid RolId { set; get; }
        public bool Validacion()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Direccion))
            {
                return false;
            }

          /*  if (Telefono != null)
            {
                return false;
            }
            if (DNI != null)
            {
                return false;
            } */
            if (string.IsNullOrEmpty(Sexo))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Correo))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Contraseña2))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Contraseña))
            {
                return false;
            }

            return true;
        }
    }
}
