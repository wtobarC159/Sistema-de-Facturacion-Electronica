using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Facturacion_Electronica.Dtos.Cliente;
using Sistema_de_Facturacion_Electronica.Dtos.Producto;
using Sistema_de_Facturacion_Electronica.Helpers;
using Sistema_de_Facturacion_Electronica.Interfaces;
using Sistema_de_Facturacion_Electronica.Mapas;
using Sistema_de_Facturacion_Electronica.Modelos;
using System.Threading.Tasks;


namespace Sistema_de_Facturacion_Electronica.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ControladorProducto : ControllerBase
    {
        private readonly IProducto _producto;

        public ControladorProducto(IProducto producto) 
        { 
            _producto = producto;
        }

        [Authorize]
        [HttpGet("getproductos")]
        public async Task<IActionResult> GetProductos([FromQuery] QueryObject Query)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var ListaProducto = await _producto.ObtenerProductos(Query);
            return Ok(ListaProducto.Select(p=>p.ToProductoDTO()).ToList());
        }

        [Authorize]
        [HttpGet("{ProductoId:int}")]
        public async Task<IActionResult> GetProducto([FromRoute]int ProductoId)
        {
            var ModeloProducto = await _producto.ObtenerProductoId(ProductoId);
            if (ModeloProducto == null) return NotFound("El Producto no se encuentra registrado");
            return Ok(ModeloProducto.ToProductoDTO());
        }

        [Authorize]
        [HttpPost("postproducto")]
        public async Task<IActionResult> PostProducto([FromBody] CrearProductoDTO crearProductoDTO)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var ModeloProducto = await _producto.CrearProducto(crearProductoDTO.ToProductoCreate());
            if (ModeloProducto == null) return Conflict("Este producto ya se encuentra registrado");
            return CreatedAtAction(nameof(GetProducto), new { ProductoId = ModeloProducto.Id},ModeloProducto.ToProductoDTO());
        }

        [Authorize]
        [HttpPut("{ProductoId:int}")]
        public async Task<IActionResult> PutProducto([FromRoute]int ProductoId, [FromBody] ActualizarProductoDTO actualizarProductoDTO)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var ModeloProducto = await _producto.ActualizarProducto(ProductoId,actualizarProductoDTO);
            if (ModeloProducto == null) return NotFound($"El producto con el id:{ProductoId} no se encuentra registrado en el sistema");
            return Ok(ModeloProducto.ToProductoDTO());
        }

        [Authorize]
        [HttpDelete("{ProductoId:int}")]
        public async Task<IActionResult> DeleteProducto([FromRoute] int ProductoId)
        {
            var ModeloProducto = await _producto.EliminarProducto(ProductoId);
            if (ModeloProducto == null) return NotFound($"El producto con el id:{ProductoId} no se encuentra registrado en el sistema");
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{ProductoId:int}")]
        public async Task<IActionResult> PatchProducto([FromRoute] int ProductoId, [FromBody] ActualizarParcialDTOPR actualizarParcialDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ModeloProducto = await _producto.ActualizarParcialpr(ProductoId, actualizarParcialDTO);
            if (ModeloProducto == null)
            {
                return NotFound($"El Cliente con el ID: {ProductoId} no se encuentra registrado en el sistema");
            }

            return Ok(ModeloProducto.ToProductoDTO());
        }
    }
}

