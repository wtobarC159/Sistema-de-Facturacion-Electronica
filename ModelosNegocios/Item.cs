using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int CantidadProducto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalImpuesto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public int idProducto { get; set; }
        public Producto? Producto { get; set; }
        public int idFactura { get; set; }
        public Factura? Factura { get; set; }
    }
}
