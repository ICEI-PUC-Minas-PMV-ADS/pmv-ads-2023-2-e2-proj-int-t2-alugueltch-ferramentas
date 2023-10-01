using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models; // Substitua pelo namespace correto da sua classe de modelo personalizada
using MVC.NewClasses;
using System.Collections.Generic;

public class cadastrarFuncionariosController : Controller
{
    private readonly atdbContext _context;

    public cadastrarFuncionariosController(atdbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        ViewData["Papel"] = new SelectList(_context.TipoPapels, "Id", "Nome");
        ViewData["Permissao"] = new SelectList(_context.TipoPermissaos, "Id", "Nome");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CadastrarFuncionario funcionarioFormulary)
    {

    

        return View();
    }



}
