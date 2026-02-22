using Sistema_de_Facturacion_Electronica.Dtos.Producto;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaProducto
    {
        public static ProductoDTO ToProductoDTO(this Producto NodoProducto) 
        {
            return new ProductoDTO
            {
                Id = NodoProducto.Id,
                Codigo = NodoProducto.Codigo,
                Nombre = NodoProducto.Nombre,
                Descripcion = NodoProducto.Descripcion,
                Precio = NodoProducto.Precio,
                UnidadMedida = NodoProducto.UnidadMedida,
                ImpuestosPRD = NodoProducto.ImpuestosPRD,
            };
        }
        public static Producto ToProductoCreate(this CrearProductoDTO NodoProducto)
        {
            return new Producto
            {
                Codigo = NodoProducto.CodigoProducto,
                Nombre = NodoProducto.Nombre,
                Descripcion = NodoProducto.Descripcion,
                Precio = NodoProducto.Precio,
                UnidadMedida = NodoProducto.UnidadMedida,
                ImpuestosPRD = NodoProducto.ImpuestosPRD,
            };
        }
    }
}
