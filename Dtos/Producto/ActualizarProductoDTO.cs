using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Producto
{
    public class ActualizarProductoDTO
    {
        [Required]
        [MaxLength(5, ErrorMessage = "El Codigo debe estar compuesto de 5 caracteres")]
        [MinLength(5)]
        public string CodigoProducto { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "El nombre no debe superar los 50 caracteres ni ser inferior a 5")]
        [MinLength(5)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "La Descripcion no debe superar los 50 caracteres ni ser inferior a 10")]
        [MinLength(5)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        [Range(0.001, 100000)]
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        [Required]
        [MaxLength(30, ErrorMessage = "Los nombres de impuestos no deben superar los 30 caracteres")]
        public string ImpuestosPRD { get; set; } = string.Empty;
    }
}
