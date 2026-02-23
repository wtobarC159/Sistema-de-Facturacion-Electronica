using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Producto
{
    public class ActualizarParcialDTOPR
    {
        [MaxLength(5, ErrorMessage = "El Codigo debe estar compuesto de 5 caracteres")]
        public string? CodigoProducto { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres ni ser inferior a 10")]
        public string? Nombre { get; set; } 
        [MaxLength(100, ErrorMessage = "La Descripcion no debe superar los 100 caracteres ni ser inferior a 10")]
        public string? Descripcion { get; set; } = string.Empty;
        public decimal? Precio { get; set; }
        public string? UnidadMedida { get; set; } 
        [MaxLength(30, ErrorMessage = "Los nombres de impuestos no deben superar los 30 caracteres")]
        public string? ImpuestosPRD { get; set; } 
    }
}
