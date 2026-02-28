
namespace Sistema_de_Facturacion_Electronica.Dtos.Item
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int CantidadProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal Total { get; set; }
    }
}
