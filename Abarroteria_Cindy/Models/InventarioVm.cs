﻿using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class InventarioVm
    {
        public Guid Id_Inventario { get; set; }
        public int Stock_Actual { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
        public Guid Id_Proveedor { set; get; }
        public ProveedorVm? Proveedor { get; set; }
        public Guid? Id_Producto { set; get; }
        public ProductoVm? Producto { get; set; }
    }
}
