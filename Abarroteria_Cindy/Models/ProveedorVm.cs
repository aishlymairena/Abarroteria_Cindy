using Abarroteria_Cindy.Data.Entidades;
using System.Text.RegularExpressions;

namespace Abarroteria_Cindy.Models
{
    public class ProveedorVm
    {
        public Guid? Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool Validacion()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }

            if (Telefono.ToString().Length != 8 || Telefono <= 0)
            {
                return false;
            }

            if (string.IsNullOrEmpty(Correo) || !Regex.IsMatch(Correo, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Direccion))
            {
                return false;
            }

            return true;
        }
    }
}
