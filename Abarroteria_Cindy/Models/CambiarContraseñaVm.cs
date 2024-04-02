namespace Abarroteria_Cindy.Models
{
    public class CambiarContraseñaVm
    {
        public Guid Id_Empleado { get; set; }
        public string ContraseñaAnterior { get; set; }
        public string NuevaContraseña { get; set; }
        public string ConfirmarContraseña { get; set; }
    }
}
