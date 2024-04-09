using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Rol
    {
        public Rol()
        {
            Empleados = new HashSet<Empleado>();
            ModulosRoles = new HashSet<ModulosRole>();
        }

        public Guid Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<ModulosRole> ModulosRoles { get; set; }
    }
}
