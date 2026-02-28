using Sistema_de_Facturacion_Electronica.Data;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Servicios
{
    public class CalculosFacturas : ICalculoFactura
    {
        private readonly IFactura _factura;
        public CalculosFacturas(IFactura factura) 
        {
            _factura = factura;
        }
        public async Task<Factura?> Facturacion(Factura NodoFactura)
        {
            var ListItem = NodoFactura.Items.ToList();
            foreach (var item in ListItem) 
            {
                NodoFactura.Subtotal += item.Subtotal;
                NodoFactura.TotalIPT += item.TotalImpuesto;
            }
            NodoFactura.TotalFinal = NodoFactura.Subtotal + NodoFactura.TotalIPT - (NodoFactura.Descuento ?? 0);
            NodoFactura.EstadoValidacion = "Sin Validar";
            NodoFactura.EstadoDePago = "Pendiente";
            var NodoFactura2 = await _factura.ActualizarFacturas(NodoFactura.Id,NodoFactura);
            return NodoFactura2;
        }
    }
}
