namespace Abarroteria_Cindy.Data.Entidades
{
    public class Proveedor
    {
        public Guid Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public Guid Id_Inventario { set; get; }
        public Inventario Inventario { get; set; }


    }
}
