using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteLN _clienteLN;

        public ClienteController(IClienteLN clienteLN)
        {
            _clienteLN = clienteLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _clienteLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] TCliente cliente)
        {
            var resultado = _clienteLN.Buscar(cliente);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener([FromBody] TCliente cliente)
        {
            var resultado = _clienteLN.Obtener(cliente);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] TCliente cliente)
        {
            var resultado = _clienteLN.Insertar(cliente);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] TCliente cliente)
        {
            var resultado = _clienteLN.Modificar(cliente);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar([FromBody] TCliente cliente)
        {
            var resultado = _clienteLN.Eliminar(cliente);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}