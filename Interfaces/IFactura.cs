using Sistema_de_Facturacion_Electronica.Dtos.Factura;
using Sistema_de_Facturacion_Electronica.Dtos.Item;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface IFactura
    {
        Task<Factura?> RegistrarFactura(Factura NodoFactura);
        Task<Factura?> AnularFactura(int IdFactura);
        Task<List<Factura>> ObtenerFacturas(QueryFactura NodoQuery);
        Task<Factura?> ObtenerFacturaId(int IdFactura);
        Task <Item?>CrearItems(Item NodoItem);
        Task<Factura?> ActualizarFacturas(int IdFactura,Factura NodoFactura);
    }
}
