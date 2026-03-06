using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int CantidadProducto { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
        public double TotalImpuesto { get; set; }
        public double Total { get; set; }

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }
    }
}
