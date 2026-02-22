using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Cliente
{
    public class ActualizarParcialDTOCL
    {
        [MaxLength(50, ErrorMessage = "El nombre no debe superar los 50 caracteres ni ser inferior a 20")]
        public string? Nombres { get; set; } 
        [MaxLength(13, ErrorMessage = "El RUC no es valido, debe contener 13 digitos")]
        public string? RUC { get; set; } 
        [MaxLength(50, ErrorMessage = "La Direccion no debe superar los 50 caracteres ni ser inferior a 10")]
        public string? Direccion { get; set; }
        [MaxLength(50, ErrorMessage = "La Direccion de correo no debe superar los 50 caracteres ni ser inferior a 10")]
        public string? Correo { get; set; }
        [MaxLength(10, ErrorMessage = "La Direccion de correo no debe superar los 10 caracteres")]
        public string? TipoContribuyente { get; set; } 
    }
}
