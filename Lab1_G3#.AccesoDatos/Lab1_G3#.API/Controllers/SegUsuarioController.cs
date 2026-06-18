using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3.LogicaNegocios.Implementaciones;
using Lab1_G3_.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegUsuarioController : ControllerBase
    {
        private readonly IUsuarioLN _segUsuarioLN;

        public SegUsuarioController(IUsuarioLN segUsuarioLN)
        {
            _segUsuarioLN = segUsuarioLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _segUsuarioLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] TSegUsuario usuario)
        {
            var resultado = _segUsuarioLN.Buscar(usuario);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener([FromBody] TSegUsuario usuario)
        {
            var resultado = _segUsuarioLN.Obtener(usuario);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] TSegUsuario usuario)
        {
            var resultado = _segUsuarioLN.Insertar(usuario);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] TSegUsuario usuario)
        {
            var resultado = _segUsuarioLN.Modificar(usuario);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar([FromBody] TSegUsuario usuario)
        {
            var resultado = _segUsuarioLN.Eliminar(usuario);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}