namespace Abarroteria_Cindy.Data.Entidades
{
    public class Encabezado_Factura
    {
        public Guid Id_Encabezado_factura { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string NumeroFactura { get; set; }
        public string RTN { get; set; }
       
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Empleado Empleado { get; set; }
        public Guid Id_Empleado { set; get; }
        public Cliente Cliente { get; set; }
        public Guid Id_Cliente { set; get; }
        public CAI CAI { get; set; }
        public Guid Id_Cai { set; get; }
       
        public ICollection<Detalle_Factura> Detalles { get; set; }
        public ICollection<Pago> Pagos { get; set; }

        public Encabezado_Factura()
        {
            Detalles = new HashSet<Detalle_Factura>();
            Pagos = new HashSet<Pago>();

        }
    }
}