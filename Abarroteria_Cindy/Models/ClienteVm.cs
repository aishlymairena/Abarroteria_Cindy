﻿namespace Abarroteria_Cindy.Models
{
    public class ClienteVm
    {
        public Guid Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string DNI { get; set; }
        public string? Sexo { get; set; }



        public bool Validacion()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Apellido))
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
