using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos
{
    public class RegistrarPagoDTO
    {
        [Required]
        [Range(5,10000)]
        public decimal Monto { get; set; }
        [Required]
        public DateOnly FechaPago { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="No Supere los 30 caracteres")]
        public string MetodoPago { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "No Supere los 30 caracteres")]
        public string EstadoPago { get; set; } = string.Empty;
        [Required]
        public int FacturaId { get; set; }
    }
}
