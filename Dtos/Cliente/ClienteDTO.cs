using System;

namespace Sistema_de_Facturacion_Electronica.Dtos.Cliente
{
    public class ClienteDTO
    {
        public int Id { get; set; } 
        public string Nombres { get; set; } = string.Empty;
        public string RUC { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string TipoContribuyente { get; set; } = string.Empty;
    }
}
