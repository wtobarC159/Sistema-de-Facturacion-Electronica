using Sistema_de_Facturacion_Electronica.Dtos;
using Sistema_de_Facturacion_Electronica.Dtos.Pago;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaPagos
    {
        public static PagoDTO ToPagoDTO(this Pago NodoPago) 
        {
            return new PagoDTO 
            {
                Id = NodoPago.Id,
                Monto = NodoPago.Monto,
                FechaPago = NodoPago.FechaPago,
                MetodoPago = NodoPago.MetodoPago,
                EstadoPago = NodoPago.EstadoPago,
                FacturaId = NodoPago.FacturaId,               
            };

        }

        public static Pago ToPago(this RegistrarPagoDTO NodoPago)
        {
            return new Pago 
            {
                Monto = NodoPago.Monto,
                FechaPago = NodoPago.FechaPago,
                MetodoPago = NodoPago.MetodoPago,
                EstadoPago = NodoPago.EstadoPago,
                FacturaId = NodoPago.FacturaId,
            };
        }
    }
}
