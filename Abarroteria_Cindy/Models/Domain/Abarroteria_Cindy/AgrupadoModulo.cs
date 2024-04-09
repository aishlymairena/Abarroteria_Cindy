using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class AgrupadoModulo
    {
        public AgrupadoModulo()
        {
            Modulos = new HashSet<Modulo>();
        }

        public Guid Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<Modulo> Modulos { get; set; }
    }
}
