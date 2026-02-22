using Sistema_de_Facturacion_Electronica.Modelos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Facturacion_Electronica.Dtos.Producto
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        public string ImpuestosPRD { get; set; } = string.Empty;
    }
}
