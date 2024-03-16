using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class ModulosRolesVm
    {
        public Guid Id { get; set; }
        public RolVm Rol { get; set; }
        public Guid RolId { get; set; }
        public ModuloVm Modulo { get; set; }
        public Guid ModuloId { get; set; }
    }
}
