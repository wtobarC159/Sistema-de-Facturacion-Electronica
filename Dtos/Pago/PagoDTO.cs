using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Dtos.Pago
{
    public class PagoDTO
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public DateOnly FechaPago { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public string EstadoPago { get; set; } = string.Empty;
        public int FacturaId { get; set; }
    }
}
