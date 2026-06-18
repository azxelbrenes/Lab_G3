using Lab1_G3.Dominio.EntidadesTipadas;
using Lab1_G3.Dominio.InterfacesLN;
using Lab1_G3_.Dominio.InterfacesLN;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_G3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoCedulaController : ControllerBase
    {
        private readonly ITipoCedulaLN _tipoCedulaLN;

        public TipoCedulaController(ITipoCedulaLN tipoCedulaLN)
        {
            _tipoCedulaLN = tipoCedulaLN;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var resultado = _tipoCedulaLN.Listar();

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Buscar")]
        public IActionResult Buscar([FromBody] TTipoCedula tipoCedula)
        {
            var resultado = _tipoCedulaLN.Buscar(tipoCedula);

            if (!resultado.blnIndicadorTransaccion)
                return NotFound(resultado);

            return Ok(resultado);
        }

        [HttpPost("Obtener")]
        public IActionResult Obtener([FromBody] TTipoCedula tipoCedula)
        {
            var resultado = _tipoCedulaLN.Obtener(tipoCedula);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] TTipoCedula tipoCedula)
        {
            var resultado = _tipoCedulaLN.Insertar(tipoCedula);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpPut("Modificar")]
        public IActionResult Modificar([FromBody] TTipoCedula tipoCedula)
        {
            var resultado = _tipoCedulaLN.Modificar(tipoCedula);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Eliminar([FromBody] TTipoCedula tipoCedula)
        {
            var resultado = _tipoCedulaLN.Eliminar(tipoCedula);

            if (!resultado.blnIndicadorTransaccion)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}