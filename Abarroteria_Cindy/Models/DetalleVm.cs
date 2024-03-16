using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class DetalleVm
    {
        public Guid Id_Detalle_Factura { get; set; }
        public int Cantidad { get; set; }
        public int Total_Linea { get; set; }
        public EncabezadoVm Encabezado_Factura { get; set; }
        public Guid Id_Encabezado_Factura { set; get; }
    }
}
