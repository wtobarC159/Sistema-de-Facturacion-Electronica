using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Item
{
    public class CrearItemDTO
    {
        [Required]
        public int IdProducto { get; set; }
        [Required]
        [Range(1,100)]
        public int CantidadProducto { get; set; }
        [Required]
        public int IdFactura { get; set; }
    }
}
