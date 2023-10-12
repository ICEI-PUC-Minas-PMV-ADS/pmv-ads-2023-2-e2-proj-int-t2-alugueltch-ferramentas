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
        public async Task<ActionResult<Cliente>> BuscarFerramentaPorDescricaoOuMarca(string descricao, [FromQuery] string marca)
        {

            return Ok(await _context.Ferramenta.FirstOrDefaultAsync(x => x.Descricao == descricao &&  x.Marca == marca));
        }
    }
    }

