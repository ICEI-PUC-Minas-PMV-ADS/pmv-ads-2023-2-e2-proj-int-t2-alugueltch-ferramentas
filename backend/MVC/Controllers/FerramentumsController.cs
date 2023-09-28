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
    public class FerramentumsController : Controller
    {
        private readonly ATDBContext _context;

        public FerramentumsController(ATDBContext context)
        {
            _context = context;
        }

        // GET: Ferramentums
        public async Task<IActionResult> Index()
        {
            var aTDBContext = _context.Ferramenta.Include(f => f.Situacao).Include(f => f.Tipo);
            return View(await aTDBContext.ToListAsync());
        }

        // GET: Ferramentums/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Ferramenta == null)
            {
                return NotFound();
            }

            var ferramentum = await _context.Ferramenta
                .Include(f => f.Situacao)
                .Include(f => f.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ferramentum == null)
            {
                return NotFound();
            }

            return View(ferramentum);
        }

        // GET: Ferramentums/Create
        public IActionResult Create()
        {
            ViewData["SituacaoId"] = new SelectList(_context.TipoSituacaos, "Id", "Id");
            ViewData["TipoId"] = new SelectList(_context.TipoFerramenta, "Id", "Id");
            return View();
        }

        // POST: Ferramentums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,TipoId,Marca,Descricao,SituacaoId,CadastradoPor,ValorDiaria,ValorCompra")] Ferramentum ferramentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ferramentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SituacaoId"] = new SelectList(_context.TipoSituacaos, "Id", "Id", ferramentum.SituacaoId);
            ViewData["TipoId"] = new SelectList(_context.TipoFerramenta, "Id", "Id", ferramentum.TipoId);
            return View(ferramentum);
        }

        // GET: Ferramentums/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Ferramenta == null)
            {
                return NotFound();
            }

            var ferramentum = await _context.Ferramenta.FindAsync(id);
            if (ferramentum == null)
            {
                return NotFound();
            }
            ViewData["SituacaoId"] = new SelectList(_context.TipoSituacaos, "Id", "Id", ferramentum.SituacaoId);
            ViewData["TipoId"] = new SelectList(_context.TipoFerramenta, "Id", "Id", ferramentum.TipoId);
            return View(ferramentum);
        }

        // POST: Ferramentums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Codigo,TipoId,Marca,Descricao,SituacaoId,CadastradoPor,ValorDiaria,ValorCompra")] Ferramentum ferramentum)
        {
            if (id != ferramentum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ferramentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FerramentumExists(ferramentum.Id))
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
            ViewData["SituacaoId"] = new SelectList(_context.TipoSituacaos, "Id", "Id", ferramentum.SituacaoId);
            ViewData["TipoId"] = new SelectList(_context.TipoFerramenta, "Id", "Id", ferramentum.TipoId);
            return View(ferramentum);
        }

        // GET: Ferramentums/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Ferramenta == null)
            {
                return NotFound();
            }

            var ferramentum = await _context.Ferramenta
                .Include(f => f.Situacao)
                .Include(f => f.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ferramentum == null)
            {
                return NotFound();
            }

            return View(ferramentum);
        }

        // POST: Ferramentums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Ferramenta == null)
            {
                return Problem("Entity set 'ATDBContext.Ferramenta'  is null.");
            }
            var ferramentum = await _context.Ferramenta.FindAsync(id);
            if (ferramentum != null)
            {
                _context.Ferramenta.Remove(ferramentum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FerramentumExists(long id)
        {
          return (_context.Ferramenta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
