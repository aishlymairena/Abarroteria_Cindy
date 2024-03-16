namespace Abarroteria_Cindy.Data.Entidades
{
    public class Modulo
    {
        public Guid Id { set; get; }
        public string Nombre { set; get; }
        public string Metodo { set; get; }
        public string Controller { set; get; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public AgrupadoModulos AgrupadoModulos { get; set; }
        public Guid AgrupadoModulosId { get; set; }
        public ICollection<ModulosRoles> ModulosRoles { get; set; }
        public Modulo()
        {
            ModulosRoles = new HashSet<ModulosRoles>();
        }
    }
}
