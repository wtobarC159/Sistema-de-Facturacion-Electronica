using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }
        public int CantidadProducto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal PrecioUnitario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Total { get; set; }

        public int idProducto { get; set; }
        public Producto? Producto { get; set; }
        public int idFactura { get; set; }
        public Factura? Factura { get; set; }
    }
}
