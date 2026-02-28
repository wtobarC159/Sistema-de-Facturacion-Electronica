using Microsoft.EntityFrameworkCore;
using Sistema_de_Facturacion_Electronica.Data;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Respositorios
{
    public class RespositorioFactura : IFactura
    {
        private readonly Contexto _contexto;
        public RespositorioFactura(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Factura?> ActualizarFacturas(int IdFactura, Factura NodoFactura)
        {
            var DataFactura = await _contexto.Facturas.Include(p => p.Items).FirstOrDefaultAsync(m => m.Id == IdFactura);

            DataFactura!.FechaAutorizacion = NodoFactura.FechaAutorizacion;
            DataFactura!.NumeroAutorizacion = NodoFactura.NumeroAutorizacion;
            DataFactura!.Subtotal = NodoFactura.Subtotal;
            DataFactura!.TotalIPT = NodoFactura.TotalIPT;
            DataFactura!.TotalFinal = NodoFactura.TotalFinal;
            DataFactura!.EstadoValidacion = NodoFactura.EstadoValidacion;
            DataFactura!.EstadoDePago = NodoFactura.EstadoDePago;
            DataFactura!.Observaciones = NodoFactura.Observaciones;
            await _contexto.SaveChangesAsync();
            return DataFactura;
        }

        public async Task<Factura?> AnularFactura(int IdFactura)
        {
            var DataFactura = await _contexto.Facturas.FirstOrDefaultAsync(m => m.Id == IdFactura);
            if(DataFactura == null) return null;
            _contexto.Facturas.Remove(DataFactura);
            await _contexto.SaveChangesAsync();
            return DataFactura;
        }

        public async Task<Item?> CrearItems(Item NodoItem)
        {
            var DataProducto = await _contexto.Productos.Include(p => p.ImpAplicables).FirstOrDefaultAsync(m => m.Id == NodoItem.idProducto);
            if(DataProducto == null) return null;

            NodoItem.NombreProducto = DataProducto.Nombre;
            NodoItem.PrecioUnitario = DataProducto.Precio;
            NodoItem.Subtotal = NodoItem.CantidadProducto * DataProducto.Precio;
            var ListaImpuesto = DataProducto.ImpAplicables;
            foreach(var e in ListaImpuesto) 
            {
                NodoItem.TotalImpuesto += NodoItem.Subtotal * (e.Porcentaje/100);
            }
            NodoItem.Total = NodoItem.Subtotal + NodoItem.TotalImpuesto;
            await _contexto.Items.AddAsync(NodoItem);
            await _contexto.SaveChangesAsync();
            return NodoItem;
        }

        public async Task<Factura?> ObtenerFacturaId(int IdFactura)
        {
            var DataFactura = await _contexto.Facturas.Include(p => p.Items).Include(r => r.Pagos).FirstOrDefaultAsync(m => m.Id == IdFactura);
            if(DataFactura == null) return null;
            return DataFactura;
        }

        public async Task<List<Factura>> ObtenerFacturas(QueryFactura NodoQuery)
        {
            var DataFactura =  _contexto.Facturas.Include(p => p.Items).Include(r => r.Pagos).AsQueryable();
            var PaginasPaso = (NodoQuery.NumeroPagina - 1) * NodoQuery.TamanoPagina;
            return await DataFactura.Skip(PaginasPaso).Take(NodoQuery.TamanoPagina).ToListAsync();
        }

        public async Task<Factura?> RegistrarFactura(Factura NodoFactura)
        {
            await _contexto.Facturas.AddAsync(NodoFactura);
            await _contexto.SaveChangesAsync();
            return NodoFactura;
        }
    }
}
