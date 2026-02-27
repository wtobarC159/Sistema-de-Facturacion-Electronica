using Sistema_de_Facturacion_Electronica.Dtos.Item;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaItem
    {
        public static ItemDTO ToItemDTO(this Item NodoItem) 
        {
            return new ItemDTO 
            {
                Id = NodoItem.Id,
                NombreProducto = NodoItem.NombreProducto,
                CantidadProducto = NodoItem.CantidadProducto,
                PrecioUnitario = NodoItem.PrecioUnitario,
                Subtotal = NodoItem.Subtotal,
                Total = NodoItem.Total,
            };
        }

        public static Item ToItem(this CrearItemDTO NodoItem) 
        {
            return new Item 
            {
                idProducto = NodoItem.IdProducto,
                CantidadProducto = NodoItem.CantidadProducto,
                idFactura = NodoItem.IdFactura,
            };
        }
    }
}
