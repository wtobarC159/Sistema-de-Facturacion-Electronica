using System;
using Microsoft.AspNetCore.Identity;

namespace Sistema_de_Facturacion_Electronica.Modelos
{
    public class Usuario:IdentityUser
    {
        public List<Factura> facturas = new List<Factura>();
        public List<Pago> pagos = new List<Pago>();
    }
}
