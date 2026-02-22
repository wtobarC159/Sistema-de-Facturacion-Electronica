namespace Sistema_de_Facturacion_Electronica.Dtos.Usuario
{
    public class UsuarioAutenticado
    {
        public string Email { get; set; } = string.Empty;
        public string Username { get; set;} = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
