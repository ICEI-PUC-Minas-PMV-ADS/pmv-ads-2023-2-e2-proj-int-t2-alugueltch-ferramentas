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
        public async Task<ActionResult<Ferramentum>> BuscarFerramentaPorDescricaoOuMarca(string descricao, [FromQuery] string marca)
        {

            if (string.IsNullOrEmpty(descricao) || string.IsNullOrEmpty(marca))
            {
                return BadRequest("Os parâmetros 'descricao' e 'marca' precisam ser preenchidos.");
            }
            var query = _context.Ferramenta.AsQueryable(); //consulta sem filtro.

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(x => x.Descricao.Contains(descricao) && x.Marca.Contains(descricao));
            }

            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(x => x.Marca.Contains(marca));
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

