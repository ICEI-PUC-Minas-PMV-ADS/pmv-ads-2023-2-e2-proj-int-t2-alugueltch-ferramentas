using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly atdbContext _context;

        public FuncionariosController(atdbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var atdbContext = _context.Funcionarios.Include(f => f.Endereco).Include(f => f.Papel).Include(f => f.Permissao);
            return View(await atdbContext.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Endereco)
                .Include(f => f.Papel)
                .Include(f => f.Permissao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Id");
            ViewData["PapelId"] = new SelectList(_context.TipoPapels, "Id", "Id");
            ViewData["PermissaoId"] = new SelectList(_context.TipoPermissaos, "Id", "Id");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf,Nome,Sexo,DataNascimento,Email,Telefone,EnderecoId,Funcional,Senha,PermissaoId,PapelId,DataAdmissao,DataDemissao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Id", funcionario.EnderecoId);
            ViewData["PapelId"] = new SelectList(_context.TipoPapels, "Id", "Id", funcionario.PapelId);
            ViewData["PermissaoId"] = new SelectList(_context.TipoPermissaos, "Id", "Id", funcionario.PermissaoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Id", funcionario.EnderecoId);
            ViewData["PapelId"] = new SelectList(_context.TipoPapels, "Id", "Id", funcionario.PapelId);
            ViewData["PermissaoId"] = new SelectList(_context.TipoPermissaos, "Id", "Id", funcionario.PermissaoId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Cpf,Nome,Sexo,DataNascimento,Email,Telefone,EnderecoId,Funcional,Senha,PermissaoId,PapelId,DataAdmissao,DataDemissao")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Id", funcionario.EnderecoId);
            ViewData["PapelId"] = new SelectList(_context.TipoPapels, "Id", "Id", funcionario.PapelId);
            ViewData["PermissaoId"] = new SelectList(_context.TipoPermissaos, "Id", "Id", funcionario.PermissaoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Endereco)
                .Include(f => f.Papel)
                .Include(f => f.Permissao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'atdbContext.Funcionarios'  is null.");
            }
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(long id)
        {
          return (_context.Funcionarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
