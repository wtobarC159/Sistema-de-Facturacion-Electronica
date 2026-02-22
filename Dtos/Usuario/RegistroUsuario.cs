using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Facturacion_Electronica.Dtos.Usuario
{
    public class RegistroUsuario 
    {
        [Required(ErrorMessage ="Este Campo es Obligatorio")]
        [EmailAddress(ErrorMessage ="Ingrese un E-mail Valido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        [MaxLength(50, ErrorMessage = "El Username debe contener maximo 50 caracteres")]
        [MinLength(10, ErrorMessage = "El Username debe contener minimo 10 caracteres")]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Contraseña { get; set; } = string.Empty;
    }
    
    
}
