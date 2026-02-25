using Sistema_de_Facturacion_Electronica.Dtos.Factura;
using Sistema_de_Facturacion_Electronica.Dtos.Item;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface IFactura
    {
        Task<Factura?> RegistrarFactura(Factura NodoFactura);
        Task<Factura?> AnularFactura(int IdFactura);
        Task<Factura?> ObtenerFactura(int IdFactura);
        Task <Item?>CrearItems(Item NodoItem,Factura NodoFactura);
    }
}
