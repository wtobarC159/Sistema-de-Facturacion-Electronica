using Sistema_de_Facturacion_Electronica.Dtos.Pago;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface IPago
    {
        Task<List<Pago>> ListarPagos(QueryObject Query);
        Task<Pago?> ObtenerPago(int PagoId);
        Task<Pago?> RegistrarPago(Pago NodoPago);
        Task<Pago?> ActualizarPago(int PagoId, ActualizarPago NodoPago);
        Task<Pago?> ActualizarPagoParcialPA(int PagoId, ActualizarPagoParcialDTO NodoPago);
        Task<Pago?> EliminarPago(int PagoId);
    }
}
