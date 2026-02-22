using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Pago
{
    public class ActualizarPagoParcialDTO
    {
        public DateOnly? FechaPago { get; set; }
        [MaxLength(30, ErrorMessage = "No Supere los 30 caracteres")]
        public string? MetodoPago { get; set; } 
        [MaxLength(30, ErrorMessage = "No Supere los 30 caracteres")]
        public string? EstadoPago { get; set; } 
        public int? FacturaId { get; set; }
    }
}
