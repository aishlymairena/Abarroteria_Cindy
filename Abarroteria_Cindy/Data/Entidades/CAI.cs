namespace Abarroteria_Cindy.Data.Entidades
{
    public class CAI
    {
        public Guid Id_Cai { get; set; }
        public string Cai { get; set; }
        public int Rango_Inicial { get; set; }
        public int Rango_Final { get; set; }
        public DateTime Limite_Emision { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public ICollection<Encabezado_Factura> Encabezados { get; set; }
        public CAI()
        {
            Encabezados = new HashSet<Encabezado_Factura>();
        }

    }
}
