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
    [Route("api/factura")]
    public class ControladorFactura : ControllerBase
    {
        private readonly IFactura _factura;
        //private readonly IExportacionXML _xml;
        //private readonly IValidacionXSD _xsd;
        private readonly UserManager<Usuario> _userManager;
        private readonly ICliente _cliente;
        private readonly ICalculoFactura _calculoFactura;

        public ControladorFactura(IFactura factura,/*IExportacionXML xml,IValidacionXSD xsd,*/UserManager<Usuario> userManager,ICliente cliente,ICalculoFactura calculoFactura) 
        {
            _factura = factura;
            /*_xml = xml;
            _xsd = xsd;*/
            _userManager = userManager;
            _cliente = cliente;
            _calculoFactura = calculoFactura;
        }

        [Authorize]
        [HttpGet("obtenerfactura/{IdFactura:int}")]
        public async Task<IActionResult> ObtenerFacturaID([FromRoute] int IdFactura) 
        {
            var ModeloFactura = await _factura.ObtenerFacturaId(IdFactura);
            if (ModeloFactura == null) return NotFound($"La Factrua con el id {IdFactura} no se encuentra registrada en el sistema");
            return Ok(ModeloFactura.ToFacturaDTO());
        }

        [Authorize]
        [HttpGet("obtenerfacturas")]
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
            var ModeloFactura = await _factura.RegistrarFactura(NodoFactura.ToFactura(AppUsuario!.Id,ModeloCliente!.Id));
            if (ModeloFactura == null) 
            {
                return StatusCode(500,"Error Interno del Servidor");
            }

            return CreatedAtAction(nameof(ObtenerFacturaID), new {IdFactura = ModeloFactura.Id},ModeloFactura.ToFacturaDTO());
        }

        [Authorize]
        [HttpPost("generaritem")]
        public async Task<IActionResult> GenerarItem([FromBody] CrearItemDTO NodoItem) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var ItemModelo = await _factura.CrearItems(NodoItem.ToItem());
            if (ItemModelo == null) return StatusCode(500,"Error Interno del Servidor");
            return Ok(ItemModelo);
        }

        [Authorize]
        [HttpPost("validacion")]
        public async Task<IActionResult> ValidarFactura([FromBody] int IdFactura) 
        {
           var ModeloFactura = await _factura.ObtenerFacturaId(IdFactura);
            if (ModeloFactura == null) return NotFound($"La Factura con el id {IdFactura} no se encuntra registrado");
            var ModeloFacturaPLMR = await  _calculoFactura.Facturacion(ModeloFactura);
            if (ModeloFacturaPLMR == null) return StatusCode(500,"Error Intenro del servidor");
            return Ok(ModeloFacturaPLMR.ToFacturaDTO());
        }       
    }
}
