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
        public ProductoVm Producto { get; set; }
        public Guid Id_Producto { set; get; }
       
        public bool Validacion()
        {
            if (Cantidad <= 0)
            {
                return false;
            }
            if (Total_Linea <= 0)
            {
                return false;
            }
            return true; // Retorna true si todas las validaciones pasan
        }

    }
}