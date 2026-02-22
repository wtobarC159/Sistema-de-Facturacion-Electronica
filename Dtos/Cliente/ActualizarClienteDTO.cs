using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Cliente
{
    public class ActualizarClienteDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre no debe superar los 50 caracteres ni ser inferior a 20")]
        [MinLength(20)]
        public string Nombres { get; set; } = string.Empty;
        [Required]
        [MaxLength(13, ErrorMessage = "El RUC no es valido, debe contener 13 digitos")]
        [MinLength(13, ErrorMessage = "El RUC no es valido, debe contener 13 digitos")]
        public string RUC { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "La Direccion no debe superar los 50 caracteres ni ser inferior a 10")]
        [MinLength(10)]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "La Direccion de correo no debe superar los 50 caracteres ni ser inferior a 10")]
        [MinLength(10)]
        public string Correo { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "La Direccion de correo no debe superar los 10 caracteres")]
        public string TipoContribuyente { get; set; } = string.Empty;
    }
}
