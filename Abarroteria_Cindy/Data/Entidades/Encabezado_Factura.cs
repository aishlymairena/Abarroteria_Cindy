﻿namespace Abarroteria_Cindy.Data.Entidades
{
    public class Encabezado_Factura
    {
        public Guid Id_Encabezado_factura { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string NumeroFactura { get; set; }
        public string RTN { get; set; }
        public int Total { get; set; }
        public int Monto_Entregado { get; set; }
        public int Cambio { get; set; }
        public decimal Impuesto { get; set; }
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
        public Encabezado_Factura()
        {
            Detalles = new HashSet<Detalle_Factura>();
        }
    }
}
