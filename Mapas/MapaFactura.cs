using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Sistema_de_Facturacion_Electronica.Dtos.Factura;
using Sistema_de_Facturacion_Electronica.Modelos;
namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaFactura
    {
        public static FacturaDTO ToFacturaDTO(this Factura NodoFactura) 
        {
            return new FacturaDTO
            {
                Id = NodoFactura.Id,
                //FechaEmision = NodoFactura.FechaEmision,
                //FechaAutorizacion = NodoFactura.FechaAutorizacion,
                NumeroAutorizacion = NodoFactura.NumeroAutorizacion,
                NombreCliente = NodoFactura.NombreCliente,
                Subtotal = NodoFactura.Subtotal,
                TotalIPT = NodoFactura.TotalIPT,
                Descuento = NodoFactura.Descuento,
                TotalFinal = NodoFactura.TotalFinal,
                EstadoValidacion = NodoFactura.EstadoValidacion,
                Observaciones = NodoFactura.Observaciones,
                ClienteId = NodoFactura.IdCliente,
                idInfoTRB = NodoFactura.InfoTributariaId,
                idUsuario = NodoFactura.IdUsuario,
                //InfoDTO = NodoFactura.InfoTributaria.ToInfoDto() ?? null,
                Items = NodoFactura.Items.Select(m => m.ToItemDTO()).ToList(),
                Pagos = NodoFactura.Pagos.Select(m => m.ToPagoDTO()).ToList(),
            };
        }

        public static Factura ToFactura(this CrearFacturaDTO NodoFactura, string IdUsuario, int IdCliente) 
        {
            return new Factura 
            {
                NombreCliente = NodoFactura.NombreCliente,
                Descuento = NodoFactura.Descuento,
                InfoTributariaId = NodoFactura.idInfoTRB,
                IdUsuario = IdUsuario,
                IdCliente = IdCliente,
            };
        }
    }
}
