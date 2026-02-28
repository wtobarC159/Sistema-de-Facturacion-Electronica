using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface ICalculoFactura
    {
        Task<Factura?> Facturacion(Factura NodoFactura);
    }
}
