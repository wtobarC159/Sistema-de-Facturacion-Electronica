using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Pagos")]
    public class Pago
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Monto { get; set; }
        public DateOnly FechaPago { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public string EstadoPago { get; set;} = string.Empty;

        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }
        public string idUsuario { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }
    }
}