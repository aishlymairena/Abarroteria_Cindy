﻿using Abarroteria_Cindy.Models;

namespace Abarroteria_Cindy.Data.Entidades
{
    public class Detalle_Factura
    {
        public Guid Id_Detalle_Factura { get; set; }
        public int Cantidad { get; set; }
        public int Total_Linea { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Encabezado_Factura Encabezado_Factura { get; set; }
        public Guid Id_Encabezado_Factura { set; get; }
        public Guid Id_Producto { set; get; }
        public Producto Producto { get; set; }

    }
    
}
