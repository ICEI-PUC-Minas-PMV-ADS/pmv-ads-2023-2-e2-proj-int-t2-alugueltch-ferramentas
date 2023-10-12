using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesAPIController : ControllerBase
    {
        private readonly atdbContext _context;
        public ClientesAPIController(atdbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ListarClientes()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<Cliente>> BuscarClientePorNome(string nome)
        {

            return Ok(await _context.Clientes.FirstOrDefaultAsync(x => x.Descricao == nome)); 
        }

    }
}
