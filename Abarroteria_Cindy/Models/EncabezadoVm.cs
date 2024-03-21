using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class EncabezadoVm
    {
        public Guid Id_Encabezado_factura { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string RTN { get; set; }
        public string NumeroFactura { get; set; }
        public int Total { get; set; }
        public int Monto_Entregado { get; set; }
        public int Cambio { get; set; }
        public decimal Impuesto { get; set; }
        public EmpleadoVm Empleado { get; set; }
        public Guid Id_Empleado { set; get; }
        public ClienteVm Cliente { get; set; }
        public Guid Id_Cliente { set; get; }
        public CAIVm CAI { get; set; }
        public Guid Id_Cai { set; get; }
    }
}
