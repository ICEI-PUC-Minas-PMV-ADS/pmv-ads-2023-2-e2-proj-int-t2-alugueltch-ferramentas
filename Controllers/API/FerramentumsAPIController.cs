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

        [HttpGet("{descricao}")]
        public async Task<ActionResult<List<Ferramentum>>> Listar([FromQuery] string? descricao)
        {
            var query = _context.Ferramenta.AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
            {
                query = query.Where(ferramenta => 
                    ferramenta.Descricao
                        .ToUpper()
                        .Contains(descricao.ToUpper()));
            }

            var resultados = await query
                .Include(ferramenta => ferramenta.Situacao)
                .ToListAsync();

            return Ok(resultados);
        }
    }
}


