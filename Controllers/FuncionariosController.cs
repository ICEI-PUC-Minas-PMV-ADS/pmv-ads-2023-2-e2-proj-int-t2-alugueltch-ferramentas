using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;


namespace MVC.Controllers
{
    [Authorize(Roles ="Admin")]
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
            ViewData["Papel"] = new SelectList(_context.TipoPapels, "Id", "Nome");
            ViewData["Permissao"] = new SelectList(_context.TipoPermissaos, "Id", "Nome");

            return View();

        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {

  

            if (ModelState.IsValid)
            {
                // funcionario.DataNascimento = funcionario.DataNascimento.ToUniversalTime();
                funcionario.EnderecoId = funcionario.Endereco.Id;

                _context.Add(funcionario.Endereco);
                await _context.SaveChangesAsync();


                string sexo = (funcionario.Enum_sexo.ToString() == "Masculino") ? "Masculino" : "Feminino";

                funcionario.Sexo = sexo;

                var permissao = _context.TipoPermissaos.Find(funcionario.PermissaoId);
                funcionario.Permissao = permissao;


                var papel = _context.TipoPapels.Find(funcionario.PapelId);
                funcionario.Papel = papel;



               // funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Se o ModelState não for válido, verifique os erros associados a cada campo.
                foreach (var entry in ModelState)
                {
                    var key = entry.Key; // O nome do campo
                    var errors = entry.Value.Errors; // Erros associados a esse campo

                    foreach (var error in errors)
                    {
                        var errorMessage = error.ErrorMessage; // Mensagem de erro
                                                               // Faça algo com a mensagem de erro, por exemplo, registrá-la ou tratá-la.
                        Console.WriteLine($"Campo: {key}, Erro: {errorMessage}");
                    }
                }
            }

            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Id", funcionario.EnderecoId);
            ViewData["PapelId"] = new SelectList(_context.TipoPapels, "Id", "Id", funcionario.PapelId);
            ViewData["PermissaoId"] = new SelectList(_context.TipoPermissaos, "Id", "Id", funcionario.PermissaoId);

            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(long? id, string cpf, string funcional)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id,cpf,funcional);
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
                   // funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);
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
        public async Task<IActionResult> Delete(long? id, string cpf, string funcional)
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
        public async Task<IActionResult> DeleteConfirmed(long? id, string cpf, string funcional)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'atdbContext.Funcionarios'  is null.");
            }
            var funcionario = await _context.Funcionarios.FindAsync(id,cpf,funcional);
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

        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();  
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Funcionario funcionario)
        {
            var funcDB = await _context.Funcionarios
                  .Where(f => f.Funcional == funcionario.Funcional) // Substitua 'Funcional' pelo nome da propriedade correta
                 .FirstOrDefaultAsync();

            if (funcDB == null)
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();
            }

            /* var senha = BCrypt.Net.BCrypt.Verify(funcionario.Senha, funcDB.Senha); */
            

            if (funcionario.Senha == funcDB.Senha)
            {


                string teste =  (funcDB.PermissaoId == 1) ? "Admin": "User";
    
    

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, funcDB.Nome),
                    new Claim(ClaimTypes.NameIdentifier, funcDB.Funcional),
                    new Claim(ClaimTypes.Role, teste)
              

                };


                /* new Claim(ClaimTypes.Role, funcDB.Permissao.Nome) */

                var funcionarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(funcionarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);
                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
            }

            return View();
        }

        [AllowAnonymous]
        public async  Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Funcionarios");
        }


        [AllowAnonymous]

        public async Task<IActionResult> AccessDenied()
        {
            return View();  
        }
    
    }
}
