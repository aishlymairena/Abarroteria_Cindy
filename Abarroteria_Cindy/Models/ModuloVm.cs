using Abarroteria_Cindy.Data.Entidades;

namespace Abarroteria_Cindy.Models
{
    public class ModuloVm
    {
        public Guid Id { set; get; }
        public string Nombre { set; get; }
        public string Metodo { set; get; }
        public string Controller { set; get; }
        public AgrupadoVm AgrupadoModulos { get; set; }
        public Guid AgrupadoModulosId { get; set; }
    }
}
