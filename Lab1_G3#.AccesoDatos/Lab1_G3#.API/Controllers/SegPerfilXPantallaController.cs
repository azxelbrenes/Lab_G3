using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3_.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegPerfilXPantallaController : ControllerBase
    {
        private readonly ISegPerfilXPantallaLN _segPerfilXPantallaLN;

        public SegPerfilXPantallaController(
            ISegPerfilXPantallaLN segPerfilXPantallaLN)
        {
            _segPerfilXPantallaLN = segPerfilXPantallaLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _segPerfilXPantallaLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar(
            [FromBody] TSegPerfilXpantalla segPerfilXPantalla)
        {
            var resultado =
                _segPerfilXPantallaLN.Buscar(segPerfilXPantalla);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener(
            [FromBody] TSegPerfilXpantalla segPerfilXPantalla)
        {
            var resultado =
                _segPerfilXPantallaLN.Obtener(segPerfilXPantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(
            [FromBody] TSegPerfilXpantalla segPerfilXPantalla)
        {
            var resultado =
                _segPerfilXPantallaLN.Insertar(segPerfilXPantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar(
            [FromBody] TSegPerfilXpantalla segPerfilXPantalla)
        {
            var resultado =
                _segPerfilXPantallaLN.Modificar(segPerfilXPantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar(
            [FromBody] TSegPerfilXpantalla segPerfilXPantalla)
        {
            var resultado =
                _segPerfilXPantallaLN.Eliminar(segPerfilXPantalla);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}