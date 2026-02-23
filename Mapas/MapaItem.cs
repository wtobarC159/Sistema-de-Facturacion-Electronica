using Sistema_de_Facturacion_Electronica.Dtos.Item;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaItem
    {
        public static ItemDTO ToItemDTO(this Item NodoItem) 
        {
            return new ItemDTO();
        }
    }
}
