using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sistema_de_Facturacion_Electronica.Dtos.Cliente;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Mapas;
using Sistema_de_Facturacion_Electronica.Modelos;


namespace Sistema_de_Facturacion_Electronica.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ControladorCliente : ControllerBase
    {
        private readonly ICliente _cliente;
        public ControladorCliente(ICliente cliente) 
        {
            _cliente = cliente;
        }
        [Authorize]
        [HttpGet("getclientes")]
        public async Task<IActionResult> GetClientes()
        {
            var ListaCliente = await _cliente.ObtenerClientes();
            var DtosClientes = ListaCliente.Select(p => p.ToClienteDTO()).ToList();
            return Ok(DtosClientes);
        }

        [Authorize]
        [HttpGet("{ClienteId:int}")]
        public async Task<IActionResult> GetCliente([FromRoute] int ClienteId)
        {
            var ModeloCliente = await _cliente.ObtenerClienteId(ClienteId);
            if (ModeloCliente==null) 
            {
                return NotFound($"El Cliente con el ID: {ClienteId} no se encuentra registrado en el sistema");
            }
            return Ok(ModeloCliente.ToClienteDTO());
        }

        [Authorize]
        [HttpPost("postcliente")]
        public async Task<IActionResult> PostCliente([FromBody] CrearClienteDTO crearClienteDTO)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var ModeloCliente = await _cliente.CrearCliente(crearClienteDTO.ToClienteCreate());
            if (ModeloCliente == null) 
            {
                return Conflict($"El Cliente con el RUC: {crearClienteDTO.RUC} ya se encuentra registrado en el sistema");
            }
            return CreatedAtAction(nameof(GetCliente), new { ClienteId = ModeloCliente.Id}, ModeloCliente.ToClienteDTO());
        }

        [Authorize]
        [HttpPut("{ClienteId:int}")]
        public async Task<IActionResult> PutCliente([FromRoute] int ClienteId, [FromBody] ActualizarClienteDTO actualizarClienteDTO)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var ModeloCliente = await _cliente.ActualizarCliente(ClienteId, actualizarClienteDTO);
            if (ModeloCliente == null) 
            {
                return NotFound($"El Cliente con el ID: {ClienteId} no se encuentra registrado en el sistema");
            }

            return Ok(ModeloCliente.ToClienteDTO());
        }

        [Authorize]
        [HttpDelete("{ClienteId:int}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] int ClienteId)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest();
            }
            var ModeloCliente = await _cliente.EliminarCliente(ClienteId);
            if (ModeloCliente == null) 
            {
                return NotFound($"El Cliente con el ID: {ClienteId} no se encuentra registrado en el sistema");
            }
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{ClienteId:int}")]
        public async Task<IActionResult> PatchCliente([FromRoute] int ClienteId, [FromBody] ActualizarParcialDTOCL actualizarParcialDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ModeloCliente = await _cliente.ActualizarParcialcl(ClienteId, actualizarParcialDTO);
            if (ModeloCliente == null)
            {
                return NotFound($"El Cliente con el ID: {ClienteId} no se encuentra registrado en el sistema");
            }

            return Ok(ModeloCliente.ToClienteDTO());
        }
    }
}
