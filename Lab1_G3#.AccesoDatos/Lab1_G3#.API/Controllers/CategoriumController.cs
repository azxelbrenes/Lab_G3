using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3_.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriumController : ControllerBase
    {
        private readonly ICategoriumLN _categoriumLN;

        public CategoriumController(ICategoriumLN categoriumLN)
        {
            _categoriumLN = categoriumLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _categoriumLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] TCategorium categoria)
        {
            var resultado = _categoriumLN.Buscar(categoria);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener([FromBody] TCategorium categoria)
        {
            var resultado = _categoriumLN.Obtener(categoria);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] TCategorium categoria)
        {
            var resultado = _categoriumLN.Insertar(categoria);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] TCategorium categoria)
        {
            var resultado = _categoriumLN.Modificar(categoria);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar([FromBody] TCategorium categoria)
        {
            var resultado = _categoriumLN.Eliminar(categoria);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}