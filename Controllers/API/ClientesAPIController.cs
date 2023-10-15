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
            List<Cliente> clientes = await _context.Clientes
                .Include(cliente => cliente.Endereco)
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<Endereco>> BuscarClientePorNome(string nome)
        {
            IQueryable<Cliente> query = _context.Clientes.AsQueryable();

            query = query.Where(cliente => 
                    cliente.Nome
                        .ToUpper()
                        .Contains(nome.ToUpper()));
            

            List<Cliente> clientes = await query
            .Include(cliente => cliente.Endereco)
            .ToListAsync();

            return Ok(clientes); 
        }
    }
}
