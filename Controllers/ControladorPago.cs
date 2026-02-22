using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Facturacion_Electronica.Dtos;
using Sistema_de_Facturacion_Electronica.Dtos.Pago;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Mapas;
using Sistema_de_Facturacion_Electronica.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sistema_de_Facturacion_Electronica.Controllers
{
    [Route("api/pago")]
    [ApiController]
    public class ControladorPago : ControllerBase
    {
        private readonly IPago _pago;
        public ControladorPago(IPago pago) 
        {
            _pago = pago;
        }

        [Authorize]
        [HttpGet("getpago")]
        public async Task<IActionResult> GetPagos([FromQuery]QueryObject Query)
        {
            var ListaPagos = await _pago.ListarPagos(Query);
            var DtosPagos = ListaPagos.Select(p => p.ToPagoDTO());
            return Ok(DtosPagos);
        }
        
        [Authorize]
        [HttpGet("{PagoId:int}")]
        public async Task<IActionResult> GetPago([FromRoute]int PagoId)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var PagoModelo = await _pago.ObtenerPago(PagoId);
            if (PagoModelo == null) return NotFound($"El Pago con el:{PagoId} no se encuentra registrado en el sistema");
            return Ok(PagoModelo.ToPagoDTO());
        }

        [Authorize]
        [HttpPost("postpago")]
        public async Task<IActionResult> PostPago([FromBody] RegistrarPagoDTO RegistroDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            var PagoModelo = await _pago.RegistrarPago(RegistroDto.ToPago());
            if (PagoModelo == null) return Conflict();
            return CreatedAtAction(nameof(GetPago), new { PagoId = PagoModelo.Id}, PagoModelo.ToPagoDTO());
        }

        [Authorize]
        [HttpPut("{PagoId:int}")]
        public async Task<IActionResult> PutPago([FromRoute]int PagoId, [FromBody] ActualizarPago actualizarDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var PagoModelo = await _pago.ActualizarPago(PagoId,actualizarDto);
            if (PagoModelo == null) return NotFound($"El producto con el id:{PagoId} no se encuentra registrado en el sistema");

            return Ok(PagoModelo.ToPagoDTO());
        }

        [Authorize]
        [HttpDelete("{PagoId:int}")]
        public async Task<IActionResult> DeletePago([FromRoute] int PagoId)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var PagoModelo = await _pago.EliminarPago(PagoId);
            if (PagoModelo == null) return NotFound($"El producto con el id:{PagoId} no se encuentra registrado en el sistema");
            return NoContent();
        }
    }
}
