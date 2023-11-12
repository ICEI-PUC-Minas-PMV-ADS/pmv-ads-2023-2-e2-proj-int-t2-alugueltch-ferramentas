using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly atdbContext _context;



        public ClientesController(atdbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var atdbContext = _context.Clientes.Include(c => c.Endereco);
            return View(await atdbContext.ToListAsync());
        }



    /*    public IActionResult GerarPDF()
        {
            // Crie um novo documento PDF
            Document doc = new Document();

            // Defina o stream de saída
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font titleFont = new Font(baseFont, 18, Font.BOLD, BaseColor.BLUE);

            // Adicione um título ao documento
            Paragraph title = new Paragraph("Exemplo de PDF com iTextSharp", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Estilo para o parágrafo de texto
            Font paragraphFont = new Font(baseFont, 12, Font.NORMAL, BaseColor.BLACK);

            // Adicione um parágrafo de texto
            Paragraph paragraph = new Paragraph("Este é um parágrafo de exemplo no documento PDF gerado com iTextSharp em ASP.NET Core.", paragraphFont);
            paragraph.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraph);

            string imagePath = "C:\\Users\\vitor\\Source\\Repos\\pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas\\wwwroot\\assets\\img\\loginbackground.jpg"; // Substitua pelo caminho real da imagem
            Image image = Image.GetInstance(imagePath);
            image.ScaleAbsolute(200f, 150f); // Defina o tamanho da imagem
            doc.Add(image);

            doc.Close();

            // Defina o cabeçalho de resposta para indicar que um arquivo PDF está sendo retornado
            Response.Headers.Add("Content-Disposition", "inline; filename=meu_documento.pdf");
            Response.Headers.Add("Content-Type", "application/pdf");

            // Escreva o conteúdo do PDF no corpo da resposta
            return File(memoryStream.ToArray(), "application/pdf");
        } */



        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(long? id, string cpf)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {

            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                cliente.EnderecoId = cliente.Endereco.Id;

                string sexo = (cliente.Enum_sexo_client.ToString() == "Masculino") ? "Masculino" : "Feminino";

                cliente.Sexo = sexo;
                _context.Add(cliente.Endereco);
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro", cliente.EnderecoId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(long? id,string? cpf)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c=>c.Id == id && c.Cpf==cpf);


            if (cliente == null)
            {
                return NotFound();
            }

            if (cliente.Sexo == "Masculino")
            {
                cliente.Enum_sexo_client = Enum_sexo_client.Masculino;
            }
            else
            {
                cliente.Enum_sexo_client = Enum_sexo_client.Feminino;
            }


            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro", cliente.EnderecoId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente.Endereco);
                    string sexo = (cliente.Enum_sexo_client.ToString() == "Masculino") ? "Masculino" : "Feminino";
                    cliente.Sexo = sexo;
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Bairro", cliente.EnderecoId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(long? id, string cpf)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id, string cpf)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'atdbContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id, cpf);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(long id)
        {
          return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
