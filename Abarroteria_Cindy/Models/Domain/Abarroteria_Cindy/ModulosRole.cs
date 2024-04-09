using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class ModulosRole
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid RolId { get; set; }
        public Guid ModuloId { get; set; }

        public virtual Modulo Modulo { get; set; } = null!;
        public virtual Rol Rol { get; set; } = null!;
    }
}
