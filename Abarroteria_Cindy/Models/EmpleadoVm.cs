using Abarroteria_Cindy.Data.Entidades;

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
        public bool Sexo { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public RolVm? Rol { get; set; }
        public Guid RolId { set; get; }
    }
}
