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
            if (Fecha_Nacimiento != null)
            {
                DateTime fechaNacimiento;
                if (DateTime.TryParse(Fecha_Nacimiento.ToString(), out fechaNacimiento))
                {
                    // Calcular la edad actual
                    int edad = DateTime.Today.Year - fechaNacimiento.Year;
                    if (DateTime.Today < fechaNacimiento.AddYears(edad))
                    {
                        edad--;
                    }

                    // Comprobar si la edad está dentro del rango
                    if (edad < 15 || edad > 50)
                    {
                        // La edad no está dentro del rango permitido
                        return false;
                    }
                }
                else
                {
                    // La fecha de nacimiento introducida no es válida
                    return false;
                }
            }

            if (Telefono.ToString().Length != 8 || Telefono != null)
            {
                return false;
            }
            if (DNI.Length != 13 || DNI != null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(Sexo))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Correo) || !Regex.IsMatch(Correo, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Contraseña2))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Contraseña) || Contraseña != Contraseña2)
            {
                return false;
            }

            return true;
        }
    }
}
