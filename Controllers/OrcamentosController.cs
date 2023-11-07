using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class OrcamentosController : Controller
    {
        private readonly atdbContext _context;

        public OrcamentosController(atdbContext context)
        {
            _context = context;
        }

        // GET: Orcamentoes
        public async Task<IActionResult> Index()
        {
            var atdbContext = _context.Orcamentos
                .Include(o => o.ClienteCpfNavigation)
                .Include(o => o.FerramentaCodigoNavigation)
                 .Where(o => o.active == true);
            return View(await atdbContext.ToListAsync());
        }

        // GET: Orcamentoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos
                .Include(o => o.ClienteCpfNavigation)
                .ThenInclude(cl => cl.Endereco)
                .Include(o => o.FerramentaCodigoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // GET: Orcamentoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteCpf"] = new SelectList(_context.Clientes, "Cpf", "Nome");
            ViewData["FerramentaCodigo"] = new SelectList(_context.Ferramenta, "Codigo", "Codigo");
            return View();
        }

        // POST: Orcamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteCpf,FerramentaCodigo,ValorTotal,DataOrcamento,DataValidade")] Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteCpf"] = new SelectList(_context.Clientes, "Cpf", "Cpf", orcamento.ClienteCpf);
            ViewData["FerramentaCodigo"] = new SelectList(_context.Ferramenta, "Codigo", "Codigo", orcamento.FerramentaCodigo);
            return View(orcamento);
        }

        // GET: Orcamentoes/Edit/5
        public async Task<IActionResult> Edit(long id, string ClienteCpf, string fcod)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos
                                 .Include(c => c.ClienteCpfNavigation)
                                 .ThenInclude(cl => cl.Endereco)
                                 .Include(c => c.FerramentaCodigoNavigation)
                                 .FirstOrDefaultAsync(x => x.Id == id && x.ClienteCpf == ClienteCpf && x.FerramentaCodigo == fcod);


            if (orcamento == null)
            {
                return NotFound();
            }
            ViewData["ClienteCpf"] = new SelectList(_context.Clientes, "Cpf", "Cpf", orcamento.ClienteCpf);
            ViewData["FerramentaCodigo"] = new SelectList(_context.Ferramenta, "Codigo", "Codigo", orcamento.FerramentaCodigo);
            return View(orcamento);
        }

        // POST: Orcamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ClienteCpf,FerramentaCodigo,ValorTotal,DataOrcamento,DataValidade")] Orcamento orcamento)
        {
            if (id != orcamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoExists(orcamento.Id))
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
            ViewData["ClienteCpf"] = new SelectList(_context.Clientes, "Cpf", "Cpf", orcamento.ClienteCpf);
            ViewData["FerramentaCodigo"] = new SelectList(_context.Ferramenta, "Codigo", "Codigo", orcamento.FerramentaCodigo);
            return View(orcamento);
        }

        // GET: Orcamentoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos
                .Include(o => o.ClienteCpfNavigation)
                .Include(o => o.FerramentaCodigoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // POST: Orcamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, string ClienteCpf, string FerramentaCodigo)
        {
            if (_context.Orcamentos == null)
            {
                return Problem("Entity set 'atdbContext.Orcamentos'  is null.");
            }
            var orcamento = await _context.Orcamentos.FindAsync(id, ClienteCpf, FerramentaCodigo);
            if (orcamento != null)
            {
                //_context.Orcamentos.Remove(orcamento);
                orcamento.active = false;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoExists(long id)
        {
          return (_context.Orcamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
