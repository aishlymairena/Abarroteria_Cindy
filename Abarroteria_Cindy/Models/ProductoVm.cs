using System;
using System.ComponentModel.DataAnnotations;

namespace Abarroteria_Cindy.Models
{
    public class ProductoVm
    {
        public Guid Id_Producto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Precio_Normal { get; set; }

        public int Precio_Mayorista { get; set; }

        public Guid Id_Categoria { set; get; }

        public CategoriaVm? Categoria { get; set; }

        public bool Validacion()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Descripcion))
            {
                return false;
            }
            if (Precio_Normal <= 0)
            {
                return false;
            }
            if (Precio_Mayorista <= 0)
            {
                return false;
            }
            if (Id_Categoria == Guid.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
