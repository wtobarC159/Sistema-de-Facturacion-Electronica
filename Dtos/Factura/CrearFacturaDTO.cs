using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Factura
{
    public class CrearFacturaDTO
    {
        [Required]
        [MaxLength(100,ErrorMessage ="El Nombre de Cliente no debe Superar los 100 caracteres")]
        [MinLength(10,ErrorMessage ="El Nombre de Cliente debe tener minimo 10 caracteres")]
        public string NombreCliente { get; set; } = string.Empty;
        [Range(0,100)]
        public Decimal? Descuento { get; set; }
        [Required]
        public int idInfoTRB { get; set; }
    }
}
