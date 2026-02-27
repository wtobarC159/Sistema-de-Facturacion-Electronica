using Sistema_de_Facturacion_Electronica.Dtos.Cliente;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface ICliente
    {
        Task<List<Cliente>> ObtenerClientes();
        Task <Cliente?> ObtenerClienteId(int ClienteId);
        Task<Cliente?> ObtenerClienteNombre(string Nombre);
        Task<Cliente?> CrearCliente(Cliente NodoCliente);
        Task<Cliente?> ActualizarCliente(int ClienteId, ActualizarClienteDTO NodoCliente);
        Task<Cliente?> ActualizarParcialcl(int ClienteId, ActualizarParcialDTOCL NodoCliente);
        Task<Cliente?> EliminarCliente(int ClienteId);
    }
}
