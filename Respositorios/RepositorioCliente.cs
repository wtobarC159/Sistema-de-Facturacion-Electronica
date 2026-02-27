using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Facturacion_Electronica.Data;
using Sistema_de_Facturacion_Electronica.Dtos.Cliente;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Modelos;
using System;

namespace Sistema_de_Facturacion_Electronica.Respositorios
{
    public class RepositorioCliente : ICliente
    {
        private readonly Contexto _contexto;

        public RepositorioCliente(Contexto contexto) 
        {
            _contexto = contexto;
        }

        public async Task<Cliente?> ActualizarCliente(int ClienteId, ActualizarClienteDTO NodoCliente)
        {
            var DataCliente = await _contexto.Clientes.FirstOrDefaultAsync(m=>m.Id==ClienteId);
            if (DataCliente==null)
            {
                return null;
            }

            DataCliente.Nombres = NodoCliente.Nombres;
            DataCliente.RUC = NodoCliente.RUC;
            DataCliente.Direccion = NodoCliente.Direccion;
            DataCliente.Correo = NodoCliente.Correo;
            DataCliente.TipoContribuyente = NodoCliente.TipoContribuyente;

            await _contexto.SaveChangesAsync();
            return DataCliente;
        }

        public async Task<Cliente?> ActualizarParcialcl(int ClienteId, ActualizarParcialDTOCL NodoCliente)
        {
            var DataCliente = await _contexto.Clientes.FirstOrDefaultAsync(m => m.Id == ClienteId);
            if (DataCliente == null)
            {
                return null;
            }
            if (!string.IsNullOrWhiteSpace(NodoCliente.Nombres))
                DataCliente.Nombres = NodoCliente.Nombres;

            if (!string.IsNullOrWhiteSpace(NodoCliente.RUC))
                DataCliente.RUC = NodoCliente.RUC;

            if (!string.IsNullOrWhiteSpace(NodoCliente.Direccion))
                DataCliente.Direccion = NodoCliente.Direccion;

            if (!string.IsNullOrWhiteSpace(NodoCliente.Correo))
                DataCliente.Correo = NodoCliente.Correo;

            if (!string.IsNullOrWhiteSpace(NodoCliente.TipoContribuyente))
                DataCliente.TipoContribuyente = NodoCliente.TipoContribuyente;

            await _contexto.SaveChangesAsync();
            return DataCliente;
        }

        public async Task<Cliente?> CrearCliente(Cliente NodoCliente)
        {

               var DataCliente = await _contexto.Clientes.FirstOrDefaultAsync(m => m.RUC == NodoCliente.RUC);
               if (DataCliente == null) await _contexto.Clientes.AddAsync(NodoCliente);
               else return null;
               await _contexto.SaveChangesAsync();
               return NodoCliente;
        }

        public async Task<Cliente?> EliminarCliente(int ClienteId)
        {
            var DataCliente = await _contexto.Clientes.FirstOrDefaultAsync(m => m.Id == ClienteId);
            if (DataCliente == null)
            {
                return null;
            }

            _contexto.Clientes.Remove(DataCliente);
            await _contexto.SaveChangesAsync();
            return DataCliente;
        }

        public async Task<Cliente?> ObtenerClienteId(int ClienteId)
        {
            var DataCliente = await _contexto.Clientes.FirstOrDefaultAsync(m => m.Id == ClienteId);
            if (DataCliente == null)
            {
                return null;
            }

            return DataCliente;
        }

        public async Task<Cliente?> ObtenerClienteNombre(string Nombre)
        {
            var DataCliente = await _contexto.Clientes.FirstOrDefaultAsync(m => m.Nombres.ToLower() == Nombre.ToLower());
            if (DataCliente == null) return null;
            return DataCliente;
        }

        public async Task<List<Cliente>> ObtenerClientes()
        {
            var DataCliente = await _contexto.Clientes.ToListAsync();
            return DataCliente;
        }
    }
}
