using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface IGenerarToken
    {
        public string GenerarToken(Usuario NodoUsuario, string Rol);
    }
}
