using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class PagoVm
    {
        public Guid Id { get; set; }
        public string NumeroFactura { get; set; }
        public double Impuesto { get; set; }
        public double TotalPagar { get; set; }
        public double MontoRecibido { get; set; }
        public double Cambio { get; set; }
        public double TotalImp { get; set; }
        public EncabezadoVm Encabezado { get; set; }
        public Guid Id_Encabezado_Factura { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }


       
    }
}

