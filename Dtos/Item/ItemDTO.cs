
namespace Sistema_de_Facturacion_Electronica.Dtos.Item
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int CantidadProducto { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
        public double TotalImpuesto { get; set; }
        public double Total { get; set; }
    }
}
