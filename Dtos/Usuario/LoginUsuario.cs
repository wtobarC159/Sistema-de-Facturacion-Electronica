using System.ComponentModel.DataAnnotations;
namespace Sistema_de_Facturacion_Electronica.Dtos.Usuario
{
    public class LoginUsuario
    {
        [Required(ErrorMessage ="Este Campo es Obligatorio")]
        [MaxLength(50,ErrorMessage ="El nombre de usaurio debe tener maximo 50 caracteres")]
        [MinLength(10, ErrorMessage ="El nombre de usuario debe de tener minimo 10 caracteres")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage ="Este Campos es Obligatorio")]
        public string Contraseña { get; set; } = string.Empty;
    }
}
