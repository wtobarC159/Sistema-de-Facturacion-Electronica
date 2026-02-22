using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Clientes")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string RUC { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string TipoContribuyente { get; set; } = string.Empty;

        public List<Factura> FacturaList { get; set;} = new List<Factura>();
    }
}
