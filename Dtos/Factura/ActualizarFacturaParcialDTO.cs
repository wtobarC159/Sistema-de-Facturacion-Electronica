using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Factura
{
    public class ActualizarFacturaParcialDTO
    {
        [MaxLength(100, ErrorMessage = "El Nombre de Cliente no debe Superar los 100 caracteres")]
        public string? NombreCliente { get; set; } 
        [MaxLength(100, ErrorMessage = "Los Items no deben Superar los 100 caracteres")]
        public string? Items { get; set; } 
        [Range(0, 100)]
        public Decimal? Descuento { get; set; }
        public int? idInfoTRB { get; set; }
    }
}
