namespace Abarroteria_Cindy.Data.Entidades
{
    public class Empleado
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
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Rol Rol { get; set; }
        public Guid RolId { set; get; }
        public ICollection<Encabezado_Factura> Encabezados { get; set; }
        public Empleado()
        {
            Encabezados = new HashSet<Encabezado_Factura>();
        }
    }
}
