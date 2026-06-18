using Lab1_G3.Dominio;
using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3_.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoLN _detallePedidoLN;

        public DetallePedidoController(IDetallePedidoLN detallePedidoLN)
        {
            _detallePedidoLN = detallePedidoLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _detallePedidoLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] TDetallesPedido detallePedido)
        {
            var resultado = _detallePedidoLN.Buscar(detallePedido);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener([FromBody] TDetallesPedido detallePedido)
        {
            var resultado = _detallePedidoLN.Obtener(detallePedido);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] TDetallesPedido detallePedido)
        {
            var resultado = _detallePedidoLN.Insertar(detallePedido);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] TDetallesPedido detallePedido)
        {
            var resultado = _detallePedidoLN.Modificar(detallePedido);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar([FromBody] TDetallesPedido detallePedido)
        {
            var resultado = _detallePedidoLN.Eliminar(detallePedido);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}