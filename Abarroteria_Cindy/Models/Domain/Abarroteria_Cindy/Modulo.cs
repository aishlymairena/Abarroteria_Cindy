using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Modulo
    {
        public Modulo()
        {
            ModulosRoles = new HashSet<ModulosRole>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Metodo { get; set; } = null!;
        public string Controller { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid AgrupadoModulosId { get; set; }

        public virtual AgrupadoModulo AgrupadoModulos { get; set; } = null!;
        public virtual ICollection<ModulosRole> ModulosRoles { get; set; }
    }
}
