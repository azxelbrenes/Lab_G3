using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3_.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SegPerfilController : ControllerBase
    {
        private readonly ISegPerfil _segPerfilLN;

        public SegPerfilController(ISegPerfil segPerfilLN)
        {
            _segPerfilLN = segPerfilLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _segPerfilLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] TSegPerfil perfil)
        {
            var resultado = _segPerfilLN.Buscar(perfil);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener([FromBody] TSegPerfil perfil)
        {
            var resultado = _segPerfilLN.Obtener(perfil);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] TSegPerfil perfil)
        {
            var resultado = _segPerfilLN.Insertar(perfil);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] TSegPerfil perfil)
        {
            var resultado = _segPerfilLN.Modificar(perfil);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar([FromBody] TSegPerfil perfil)
        {
            var resultado = _segPerfilLN.Eliminar(perfil);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}
