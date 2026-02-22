using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sistema_de_Facturacion_Electronica.Data;
using Sistema_de_Facturacion_Electronica.Dtos.Producto;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Respositorios
{
    public class RepositorioProducto : IProducto
    {
        private readonly Contexto _contexto;

        public RepositorioProducto(Contexto contexto) 
        {
            _contexto = contexto;
        }

        public async Task<Producto?> ActualizarParcialpr(int ProductoId, ActualizarParcialDTOPR NodoProducto)
        {
            var DataProducto = await _contexto.Productos.FirstOrDefaultAsync(m => m.Id == ProductoId);
            if (DataProducto == null) return null;

            if (!string.IsNullOrWhiteSpace(NodoProducto.CodigoProducto))
                DataProducto.Nombre = NodoProducto.CodigoProducto;

            if (!string.IsNullOrWhiteSpace(NodoProducto.Nombre))
                DataProducto.Nombre = NodoProducto.Nombre;

            if (!string.IsNullOrWhiteSpace(NodoProducto.Descripcion))
                DataProducto.Descripcion = NodoProducto.Descripcion;

            if (NodoProducto.Precio == null || NodoProducto.Precio == 0)
            {
                DataProducto.Precio = DataProducto.Precio;
            }
            else 
            {
                DataProducto.Precio = NodoProducto.Precio.Value;
            }

            if (!string.IsNullOrWhiteSpace(NodoProducto.UnidadMedida))
                DataProducto.UnidadMedida = NodoProducto.UnidadMedida;

            if (!string.IsNullOrWhiteSpace(NodoProducto.ImpuestosPRD))
                DataProducto.ImpuestosPRD = NodoProducto.ImpuestosPRD;
                await EliminarImpuesto(ProductoId);

            await EstablecerImpuesto(DataProducto);
            return DataProducto;
        }

        public async Task<Producto?> ActualizarProducto(int ProductoId, ActualizarProductoDTO NodoProducto)
        {
            var DataProducto = await _contexto.Productos.FirstOrDefaultAsync(m=>m.Id == ProductoId);
            if (DataProducto == null) return null;

            DataProducto.Codigo = NodoProducto.CodigoProducto;
            DataProducto.Nombre =  NodoProducto.Nombre;
            DataProducto.Descripcion = NodoProducto.Descripcion;
            DataProducto.Precio = NodoProducto.Precio;
            DataProducto.UnidadMedida = NodoProducto.UnidadMedida;
            DataProducto.ImpuestosPRD = NodoProducto.ImpuestosPRD;
            await EliminarImpuesto(ProductoId);
            await EstablecerImpuesto(DataProducto);
            return DataProducto;
        }

        public async Task<Producto?> CrearProducto(Producto NodoProducto)
        {
            var ExsistenciaReg = await _contexto.Productos.AnyAsync(m => m.Codigo.ToLower()== NodoProducto.Codigo.ToLower());
            if (ExsistenciaReg)
            {
                 return null;
            }
            await _contexto.Productos.AddAsync(NodoProducto);
            await _contexto.SaveChangesAsync();
            await EstablecerImpuesto(NodoProducto);
            return NodoProducto;
        }

        public async Task EliminarImpuesto(int ProductoId)
        {
            var ProductoRel = await _contexto.Productos.Include(m=>m.ImpAplicables).FirstOrDefaultAsync(p=>p.Id==ProductoId);
            ProductoRel.ImpAplicables.Clear();
            await _contexto.SaveChangesAsync();
        }

        public async Task<Producto?> EliminarProducto(int ProductoId)
        {
            var DataProducto = await _contexto.Productos.FirstOrDefaultAsync(m=>m.Id==ProductoId);
            if (DataProducto == null) return null;
            _contexto.Productos.Remove(DataProducto);
            await _contexto.SaveChangesAsync();
            return DataProducto;
        }

        public async Task EstablecerImpuesto(Producto NodoProducto)
        {
            var ProductoRel = await _contexto.Productos.Include(m=>m.ImpAplicables).FirstOrDefaultAsync(p=>p.Nombre == NodoProducto.Nombre);

            if (!string.IsNullOrWhiteSpace(NodoProducto.ImpuestosPRD))
            {

                if (NodoProducto.ImpuestosPRD.ToLower().Contains("iva"))
                {
                    var ImpuestoRel = await _contexto.Impuestos.Include(m=>m.Productos).FirstOrDefaultAsync(p=>p.TipoImpuesto == "IVA");
                    ProductoRel.ImpAplicables.Add(ImpuestoRel);
                }
                if (NodoProducto.ImpuestosPRD.ToLower().Contains("ir"))
                {
                    var ImpuestoRel = await _contexto.Impuestos.Include(m => m.Productos).FirstOrDefaultAsync(p => p.TipoImpuesto == "IR");
                    ProductoRel.ImpAplicables.Add(ImpuestoRel);
                }
                if (NodoProducto.ImpuestosPRD.ToLower().Contains("ice"))
                {
                    var ImpuestoRel = await _contexto.Impuestos.Include(m => m.Productos).FirstOrDefaultAsync(p => p.TipoImpuesto == "ICE");
                    ProductoRel.ImpAplicables.Add(ImpuestoRel);
                }
                await _contexto.SaveChangesAsync();
            }
            else 
            {
                return;
            }
        }
        public async Task<Producto?> ObtenerProductoId(int ProductoId)
        {
            return await _contexto.Productos.FirstOrDefaultAsync(m => m.Id == ProductoId);
        }

        public async Task<List<Producto>> ObtenerProductos(QueryObject Query)
        {
            var DataProducto =  _contexto.Productos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Query.SortBy)) 
            {
                DataProducto = Query.Descendente ? DataProducto.OrderByDescending(m=>m.Precio) : DataProducto.OrderBy(m=>m.Precio);
            }
            if (!string.IsNullOrWhiteSpace(Query.Referencia)) 
            {
                DataProducto = DataProducto.Where(m=>m.Nombre.Contains(Query.Referencia));
            }
            var PasoPagina = (Query.NumeroPagina - 1) * Query.TamanoPagina;

            return await DataProducto.Skip(PasoPagina).Take(Query.TamanoPagina).ToListAsync();
        }
    }
}
