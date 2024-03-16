namespace Abarroteria_Cindy.Models
{
    public class CAIVm
    {
        public Guid Id_Cai { get; set; }
        public string Cai { get; set; }
        public int Rango_Inicial { get; set; }
        public int Rango_Final { get; set; }
        public DateTime Limite_Emision { get; set; }
        public DateTime Fecha_Inicio { get; set; }
    }
}
