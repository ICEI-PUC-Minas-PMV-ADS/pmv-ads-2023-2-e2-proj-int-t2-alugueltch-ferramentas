using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosAPIController : ControllerBase
    {
        private readonly atdbContext _context;

        public FuncionariosAPIController(atdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Funcionario>>> List(
            [FromQuery] string? nome,
            [FromQuery] string? funcional)
        {

            IQueryable<Funcionario> query = this._context
                .Funcionarios;

            if (!string.IsNullOrEmpty(nome)) 
            {
                query = this.FilterEmployeeByName(query, nome);
            }

            if (!string.IsNullOrEmpty(funcional))
            {
                query = FilterEmployeeByFuncional(query, funcional);
            }

            var employees = await query
                .Include(funcionario => funcionario.Endereco)
                .Include(funcionario => funcionario.Permissao)
                .Select(funcionario => new
                {
                    funcionario.Id,
                    funcionario.Nome,
                    funcionario.Email,
                    funcionario.Telefone,
                    funcionario.Endereco,
                    funcionario.Funcional,
                    funcionario.Permissao,
                    funcionario.DataAdmissao,
                    funcionario.DataDemissao,
                })
                .ToListAsync();

            return Ok(employees);
        }

        private IQueryable<Funcionario> FilterEmployeeByName(IQueryable<Funcionario> query, string nome)
        {
            query = query
                .Where(funcionario =>
                    funcionario.Nome
                    .ToUpper()
                    .Contains(nome.ToUpper()))
                    .AsQueryable();

            return query;
        }

        private IQueryable<Funcionario> FilterEmployeeByFuncional(IQueryable<Funcionario> query, string funcional)
        {
            query = query.Where(funcionario =>
                    funcionario.Funcional
                        .ToUpper()
                        .Contains(funcional.ToUpper()));

            return query;
        }
    }
}
