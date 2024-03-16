namespace Abarroteria_Cindy.Data.Entidades
{
    public class Categoria
    {
        public Guid Id_Categoria { get; set; }
        public string Nombre { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }
    }
}
