using System;
using System.Collections.Generic;

namespace Abarroteria_Cindy.Models.Domain.Abarroteria_Cindy
{
    public partial class Cai
    {
        public Cai()
        {
            EncabezadoFacturas = new HashSet<EncabezadoFactura>();
        }

        public Guid IdCai { get; set; }
        public string Cai1 { get; set; } = null!;
        public int RangoInicial { get; set; }
        public int RangoFinal { get; set; }
        public DateTime LimiteEmision { get; set; }
        public DateTime FechaInicio { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }

        public virtual ICollection<EncabezadoFactura> EncabezadoFacturas { get; set; }
    }
}
