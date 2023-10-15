using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FerramentumsAPIController : ControllerBase
    {
        private readonly atdbContext _context;
        public FerramentumsAPIController(atdbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Ferramentum>>> ListarFerramentums()
        {
            List<Ferramentum> ferramentums = await _context.Ferramenta.ToListAsync();

            return Ok(ferramentums);
        }

        [HttpGet("{descricao}")]

        public async Task<ActionResult<Ferramentum>> BuscarFerramentaPorDescricao([FromQuery] string descricao)

        {
            if (string.IsNullOrEmpty(descricao))
            {
                return BadRequest("O parâmetro 'descricao' precisa ser preenchido");
            }
            var query = _context.Ferramenta.AsQueryable(); //consulta sem filtro.

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(x => x.Descricao.Contains(descricao));
            }
            var resultados = await query.ToListAsync();

            if (resultados == null)
            {
                return NotFound("Nenhuma ferramenta correspondente encontrada.");
            }

            return Ok(resultados);
        }

    }


}


