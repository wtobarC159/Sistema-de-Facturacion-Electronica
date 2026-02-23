using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Factura
{
    public class CrearFacturaDTO
    {
        [Required]
        [MaxLength(100,ErrorMessage ="El Nombre de Cliente no debe Superar los 100 caracteres")]
        [MinLength(10,ErrorMessage ="El Nombre de Cliente debe tener minimo 10 caracteres")]
        public string NombreCliente { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Los Items no deben Superar los 100 caracteres")]
        [MinLength(10, ErrorMessage = "Debe tener al menos un Item para generar la factrua")]
        public string Items { get; set; } = string.Empty;
        [Range(0,100)]
        public Decimal? Descuento { get; set; }
        [Required]
        public int idInfoTRB { get; set; }
    }
}
