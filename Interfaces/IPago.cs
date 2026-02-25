using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface IPago
    {
        Task<List<Pago>> ListarPagos(QueryObject Query);
        Task<Pago?> ObtenerPago(int PagoId);
        Task<Pago?> RegistrarPago(Pago NodoPago);
        Task<Pago?> EliminarPago(int PagoId);
    }
}
