using Sistema_de_Facturacion_Electronica.Dtos.Producto;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Interfaces
{
    public interface IProducto
    {
        Task<List<Producto>> ObtenerProductos(QueryObject Query);
        Task<Producto?> ObtenerProductoId(int ProductoId);
        Task<Producto?> CrearProducto(Producto NodoProducto);
        Task<Producto?> ActualizarProducto(int ProductoId,ActualizarProductoDTO NodoProducto);
        Task<Producto?> ActualizarParcialpr(int ProductoId,ActualizarParcialDTOPR NodoProducto);
        Task<Producto?> EliminarProducto(int ProductoId);
        Task EstablecerImpuesto(Producto NodoProducto);
        Task EliminarImpuesto(int ProductoId);
    }
}
