
namespace Sistema_de_Facturacion_Electronica.Dtos.Item
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int CantidadProducto { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal Subtotal { get; set; }
        public Decimal Total { get; set; }
    }
}
