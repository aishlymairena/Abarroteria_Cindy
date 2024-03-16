namespace Abarroteria_Cindy.Data.Entidades
{
    public class Rol
    {
        public Guid Id { set; get; }
        public string Descripcion { set; get; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
        public ICollection<ModulosRoles> ModulosRoles { get; set; }

        public Rol()
        {
            Empleados = new HashSet<Empleado>();
            ModulosRoles = new HashSet<ModulosRoles>();
        }
    }
}
