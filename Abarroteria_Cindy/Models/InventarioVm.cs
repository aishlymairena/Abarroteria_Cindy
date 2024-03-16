namespace Abarroteria_Cindy.Models
{
    public class InventarioVm
    {
        public Guid Id_Inventario { get; set; }
        public int Stock_Actual { get; set; }
        public int Stock_Minimo { get; set; }
        public int Stock_Maximo { get; set; }
    }
}
