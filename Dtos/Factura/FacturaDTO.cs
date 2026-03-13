using Sistema_de_Facturacion_Electronica.Dtos.InfoTributDTO;
using Sistema_de_Facturacion_Electronica.Dtos.Item;
using Sistema_de_Facturacion_Electronica.Dtos.Pago;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Dtos.Factura
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        //public DateTime FechaEmision { get; set; } = DateTime.Now;
        //public DateTime FechaAutorizacion { get; set; } = DateTime.Now;
        public string NumeroAutorizacion { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public double Subtotal { get; set; }
        public double TotalIPT { get; set; }
        public double? Descuento { get; set; }
        public double TotalFinal { get; set; }
        public string EstadoValidacion { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public string EstadoDePago { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public int idInfoTRB { get; set; }
        public string idUsuario { get; set; } = string.Empty;

        public InfoTributariaDTO? InfoDTO{ get; set; }
        public List<ItemDTO> Items { get; set; }
        public List<PagoDTO> Pagos { get; set; }
    }
}
