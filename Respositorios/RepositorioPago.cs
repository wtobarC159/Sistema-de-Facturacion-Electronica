using Microsoft.EntityFrameworkCore;
using Sistema_de_Facturacion_Electronica.Data;
using Sistema_de_Facturacion_Electronica.Dtos.Pago;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Modelos;
using System;
using System.Linq;

namespace Sistema_de_Facturacion_Electronica.Respositorios
{
    public class RepositorioPago : IPago
    {
        private readonly Contexto _contexto;

        public RepositorioPago(Contexto contexto) 
        {
            _contexto = contexto;
        }

        public async Task<Pago?> ActualizarPago(int PagoId, ActualizarPago NodoPago)
        {
            var DataPago = await _contexto.Pagos.FirstOrDefaultAsync(m=>m.Id==PagoId);
            if(DataPago == null) return null;

            DataPago.FechaPago = NodoPago.FechaPago;
            DataPago.MetodoPago = NodoPago.MetodoPago;
            DataPago.EstadoPago = NodoPago.EstadoPago;
            DataPago.FacturaId = NodoPago.FacturaId;

            await _contexto.SaveChangesAsync();
            return DataPago;
        }

        public async Task<Pago?> ActualizarPagoParcialPA(int PagoId, ActualizarPagoParcialDTO NodoPago)
        {
            /* var DataPago = await _contexto.Pagos.FirstOrDefaultAsync(m => m.Id == PagoId);
             if (DataPago == null) return null;

             if (!string.IsNullOrWhiteSpace(NodoPago.FechaPago.ToString())) 
             {
                 DataPago.FechaPago = NodoPago.FechaPago;
             }*/

            return null;
        }

        public async Task<Pago?> EliminarPago(int PagoId)
        {
            var DataPago = await _contexto.Pagos.FirstOrDefaultAsync(m => m.Id == PagoId);
            if (DataPago == null) return null;
            _contexto.Remove(DataPago);
            await _contexto.SaveChangesAsync();
            return DataPago;
        }

        public async Task<List<Pago>> ListarPagos(QueryObject Query)
        {
            var DataPago = _contexto.Pagos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Query.SortBy)) 
            {
                DataPago = Query.Descendente ? DataPago.OrderByDescending(m=>m.Monto) : DataPago.OrderBy(m=>m.Monto);
            }

            var SkipPage = (Query.NumeroPagina - 1) * Query.TamanoPagina;

            return await DataPago.Skip(SkipPage).Take(Query.NumeroPagina).ToListAsync();
        }

        public async Task<Pago?> ObtenerPago(int PagoId)
        {
            return await _contexto.Pagos.FirstOrDefaultAsync(m=>m.Id==PagoId);
        }

        public async Task<Pago?> RegistrarPago(Pago NodoPago)
        {
            await _contexto.AddAsync(NodoPago);
            await _contexto.SaveChangesAsync();
            return NodoPago;
        }
    }
}
