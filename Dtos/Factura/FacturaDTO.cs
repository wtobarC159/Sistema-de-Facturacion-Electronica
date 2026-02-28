using Sistema_de_Facturacion_Electronica.Dtos.Item;
using Sistema_de_Facturacion_Electronica.Dtos.Pago;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Dtos.Factura
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public DateTime FechaAutorizacion { get; set; }
        public string NumeroAutorizacion { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal TotalIPT { get; set; }
        public decimal? Descuento { get; set; }
        public decimal TotalFinal { get; set; }
        public string EstadoValidacion { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public string EstadoDePago { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public int idInfoTRB { get; set; }
        public string idUsuario { get; set; } = string.Empty;

        public List<ItemDTO> Items { get; set; }
        public List<PagoDTO> Pagos { get; set; }
    }
}
