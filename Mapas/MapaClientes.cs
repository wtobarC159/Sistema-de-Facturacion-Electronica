using System;
using Sistema_de_Facturacion_Electronica.Dtos.Cliente;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Mapas
{
    public static class MapaClientes
    {
        public static ClienteDTO ToClienteDTO(this Cliente NodoCliente) 
        {
            return new ClienteDTO 
            {
                Id = NodoCliente.Id,
                Nombres = NodoCliente.Nombres,
                RUC = NodoCliente.RUC,
                Direccion = NodoCliente.Direccion,
                Correo = NodoCliente.Correo,
                TipoContribuyente = NodoCliente.TipoContribuyente
            };
        }

        public static Cliente ToClienteCreate(this CrearClienteDTO NodoCliente) 
        {
            return new Cliente
            {
                Nombres = NodoCliente.Nombres,
                RUC = NodoCliente.RUC,
                Direccion = NodoCliente.Direccion,
                Correo = NodoCliente.Correo,
                TipoContribuyente = NodoCliente.TipoContribuyente
            };
        }
    }
}
