using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Item
{
    public class CrearItemDTO
    {
        [Required]
        [MaxLength(100,ErrorMessage ="El Nombre del Producto no puede susperar los 100 caracteres")]
        [MinLength(5,ErrorMessage ="El Nombre del Producto no puede ser inferior a los 5 caracteres")]
        public string NombreProducto { get; set; } = string.Empty;
        [Required]
        [Range(1,100)]
        public int CantidadProducto { get; set; }
    }
}
