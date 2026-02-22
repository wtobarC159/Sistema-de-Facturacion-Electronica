using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Pago
{
    public class ActualizarPago
    {
        [Required]
        public DateOnly FechaPago { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "No Supere los 30 caracteres")]
        public string MetodoPago { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "No Supere los 30 caracteres")]
        public string EstadoPago { get; set; } = string.Empty;
        [Required]
        public int FacturaId { get; set; }
    }
}
