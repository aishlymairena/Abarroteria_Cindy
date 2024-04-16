namespace Abarroteria_Cindy.Models
{
    public class AgrupadoVm
    {
        public Guid Id { set; get; }
        public string Descripcion { set; get; }
        public List<ModuloVm> Modulos { get; set; }
    }
}
