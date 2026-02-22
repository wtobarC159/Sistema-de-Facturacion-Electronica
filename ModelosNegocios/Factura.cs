using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Facturas")]
    public class Factura
    {
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public DateTime FechaAutorizacion { get; set; }
        public string NumeroAutorizacion { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();
        [Column(TypeName ="decimal(18,2)")]
        public Decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal TotalIPT { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal? Descuento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal TotalFinal { get; set; }
        public string EstadoValidacion { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public string EstadoDePago { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int idInfoTRB{ get; set; }
        public InfoTributaria? InfoTributaria { get; set; }
        public List<Pago> Pagos { get; set; } = new List<Pago>();
        public string idUsuario { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }  
    }
}
