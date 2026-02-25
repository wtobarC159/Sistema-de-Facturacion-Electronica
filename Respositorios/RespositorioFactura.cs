using Microsoft.EntityFrameworkCore;
using Sistema_de_Facturacion_Electronica.Data;
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

        public async Task<Factura?> AnularFactura(int IdFactura)
        {
            var DataFactura = await _contexto.Facturas.FirstOrDefaultAsync(m => m.Id == IdFactura);
            if(DataFactura == null) return null;
            _contexto.Facturas.Remove(DataFactura);
            await _contexto.SaveChangesAsync();
            return DataFactura;
        }

        public async Task<Item?> CrearItems(Item NodoItem,Factura NodoFactura)
        {
            var DataFactura = await _contexto.Facturas.FirstOrDefaultAsync(m => m.Id == NodoFactura.Id);
            NodoItem.idFactura = DataFactura!.Id;
            await _contexto.Items.AddAsync(NodoItem);
            await _contexto.SaveChangesAsync();
            return NodoItem;
        }

        public async Task<Factura?> ObtenerFactura(int IdFactura)
        {
            var DataFactura = await _contexto.Facturas.FirstOrDefaultAsync(m => m.Id == IdFactura);
            if(DataFactura == null) return null;
            return DataFactura;
        }

        public async Task<Factura?> RegistrarFactura(Factura NodoFactura)
        {
            await _contexto.Facturas.AddAsync(NodoFactura);
            await _contexto.SaveChangesAsync();
            return NodoFactura;
        }
    }
}
