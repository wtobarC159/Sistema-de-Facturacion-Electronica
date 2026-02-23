using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Producto
{
    public class CrearProductoDTO
    {
        [Required]
        [MaxLength(5, ErrorMessage = "El Codigo debe estar compuesto por 5 caracteres")]
        [MinLength(5)]
        public string CodigoProducto { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres ni ser inferior a 10")]
        [MinLength(10)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "La Descripcion no debe superar los 100 caracteres ni ser inferior a 10")]
        [MinLength(10)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        [Range(1,100000)]
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; } = string.Empty;
        [MaxLength(30, ErrorMessage = "El nombre del impuesto no debe superar los 30 caracteres")]
        public string ImpuestosPRD { get; set; } = string.Empty;
    }
}
