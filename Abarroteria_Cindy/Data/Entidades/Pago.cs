using Abarroteria_Cindy.Models;

namespace Abarroteria_Cindy.Data.Entidades
{
    public class Pago
    {
        public Guid Id { get; set; }
        public string NumeroFactura { get; set; }
        public double Impuesto { get; set; }
        public double TotalPagar { get; set; }
        public double MontoRecibido { get; set; }
        public double Cambio { get; set; }
        public double TotalImp { get; set; }
        public Encabezado_Factura Encabezado_Factura { get; set; }
        public Guid Id_Encabezado_Factura { set; get; }


        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }

        // Propiedad de navegación para acceder al encabezado de factura correspondiente
        
    }
}


