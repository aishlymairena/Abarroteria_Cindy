namespace Abarroteria_Cindy.Data.Entidades
{
    public class AgrupadoModulos
    {
        public Guid Id { set; get; }
        public string Descripcion { set; get; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Eliminado { get; set; }
        public ICollection<Modulo> Modulos { get; set; }

        public AgrupadoModulos()
        {
            Modulos = new HashSet<Modulo>();
        }
    }
}
