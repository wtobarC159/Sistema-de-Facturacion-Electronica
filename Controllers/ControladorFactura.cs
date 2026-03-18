using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Facturacion_Electronica.Dtos.Factura;
using Sistema_de_Facturacion_Electronica.Dtos.Item;
using Sistema_de_Facturacion_Electronica.Extensiones;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Mapas;
using Sistema_de_Facturacion_Electronica.Modelos;

namespace Sistema_de_Facturacion_Electronica.Controllers
{
    [Controller]
    [Route("api/v1/facturas")]
    public class ControladorFactura : ControllerBase
    {
        private readonly IFactura _factura;
        //private readonly IExportacionXML _xml;
        //private readonly IValidacionXSD _xsd;
        private readonly UserManager<Usuario> _userManager;
        private readonly ICliente _cliente;
        private readonly ICalculoFactura _calculoFactura;

        public ControladorFactura(IFactura factura,/*IExportacionXML xml,IValidacionXSD xsd,*/UserManager<Usuario> userManager, ICliente cliente, ICalculoFactura calculoFactura)
        {
            _factura = factura;
            /*_xml = xml;
            _xsd = xsd;*/
            _userManager = userManager;
            _cliente = cliente;
            _calculoFactura = calculoFactura;
        }

        [Authorize]
        [HttpGet("buscar/{IdFactura:int}")]
        public async Task<IActionResult> ObtenerFacturaID([FromRoute] int IdFactura)
        {
            var ModeloFactura = await _factura.ObtenerFacturaId(IdFactura);
            if (ModeloFactura == null) return NotFound($"La Factrua con el id {IdFactura} no se encuentra registrada en el sistema");
            return Ok(ModeloFactura.ToFacturaDTO());
        }

        [Authorize]
        [HttpGet("buscar")]
        public async Task<IActionResult> ObtenerFacturas([FromQuery] QueryFactura NodoQuery)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var ModeloFactura = await _factura.ObtenerFacturas(NodoQuery);
            var ModeloFacturaDTO = ModeloFactura.Select(m => m.ToFacturaDTO()).ToList();
            return Ok(ModeloFacturaDTO);
        }

        [Authorize]
        [HttpPost("registrarfactura")]
        public async Task<IActionResult> RegistrarFactura([FromBody] CrearFacturaDTO NodoFactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ModeloUsuario = User.GetGivenName();
            var AppUsuario = await _userManager.FindByNameAsync(ModeloUsuario);
            var ModeloCliente = await _cliente.ObtenerClienteNombre(NodoFactura.NombreCliente);
            var ModeloFactura = await _factura.RegistrarFactura(NodoFactura.ToFactura(AppUsuario!.Id, ModeloCliente!.Id));
            if (ModeloFactura == null)
            {
                return StatusCode(500, "Error Interno del Servidor");
            }

            return CreatedAtAction(nameof(ObtenerFacturaID), new { IdFactura = ModeloFactura.Id }, ModeloFactura.ToFacturaDTO());
        }

        [Authorize]
        [HttpPost("generaritem")]
        public async Task<IActionResult> GenerarItem([FromBody] CrearItemDTO NodoItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var FacturaModelo = await _factura.ObtenerFacturaId(NodoItem.IdFactura);
            var ItemModelo = await _factura.CrearItems(NodoItem.ToItem(), FacturaModelo!);
            if (ItemModelo == null) return StatusCode(500, "Error Interno del Servidor");
            return Ok(ItemModelo.ToItemDTO());
        }

        [Authorize]
        [HttpGet("{IdFactura:int}")]
        public async Task<IActionResult> ValidarFactura([FromRoute] int IdFactura)
        {
            var ModeloFactura = await _calculoFactura.Facturacion(IdFactura);
            if (ModeloFactura == null) return NotFound($"La Factura con el id {IdFactura} no se encuntra registrado");
            return Ok(ModeloFactura.ToFacturaDTO());
        }

        [Authorize]
        [HttpDelete("{IdFactura:int}")]
        public async Task<IActionResult> EliminarFactura([FromRoute] int IdFactura)
        {
            var ModeloFactura = await _factura.AnularFactura(IdFactura);
            if (ModeloFactura == null) return NotFound($"La Factura con el id {IdFactura} no se encuentra registrado en el sistema");
            return NoContent();
        }
    }
}
