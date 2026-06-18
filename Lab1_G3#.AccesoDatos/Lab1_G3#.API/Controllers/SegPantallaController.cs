using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3_.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegPantallaController : ControllerBase
    {
        private readonly ISegPantallaLN _segPantallaLN;

        public SegPantallaController(ISegPantallaLN segPantallaLN)
        {
            _segPantallaLN = segPantallaLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _segPantallaLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] TSegPantalla pantalla)
        {
            var resultado = _segPantallaLN.Buscar(pantalla);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener([FromBody] TSegPantalla pantalla)
        {
            var resultado = _segPantallaLN.Obtener(pantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] TSegPantalla pantalla)
        {
            var resultado = _segPantallaLN.Insertar(pantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] TSegPantalla pantalla)
        {
            var resultado = _segPantallaLN.Modificar(pantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar([FromBody] TSegPantalla pantalla)
        {
            var resultado = _segPantallaLN.Eliminar(pantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}