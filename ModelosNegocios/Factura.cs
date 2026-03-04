using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Facturas")]
    public class Factura
    {
        public int Id { get; set; }
        /*[Column(TypeName ="datetime")]
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        [Column(TypeName = "datetime")]
        public DateTime FechaAutorizacion { get; set; }*/
        public string NumeroAutorizacion { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalIPT { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalFinal { get; set; }
        public string EstadoValidacion { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public string? XmlFactura { get; set; }

        public List<Pago> Pagos { get; set; } = new List<Pago>();

        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        public int IdInfo { get; set; }
        public InfoTributaria? InfoTributaria { get; set; }

        public string IdUsuario { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }
    }
}
