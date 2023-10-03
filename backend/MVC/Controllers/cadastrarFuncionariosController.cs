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
    public async Task<IActionResult> Create(CadastrarFuncionario cadastrarFuncionario)
    {
        _context.Add(cadastrarFuncionario.Endereco);
        await _context.SaveChangesAsync();

        cadastrarFuncionario.Funcionario.Endereco = cadastrarFuncionario.Endereco;
        cadastrarFuncionario.Funcionario.EnderecoId = cadastrarFuncionario.Endereco.Id;

        var endereco = _context.Enderecos.Find(cadastrarFuncionario.Funcionario.EnderecoId);
        cadastrarFuncionario.Funcionario.Endereco = endereco;

        var papel = _context.TipoPapels.Find(cadastrarFuncionario.Papel);
        cadastrarFuncionario.Funcionario.Papel = papel;
        cadastrarFuncionario.Funcionario.PapelId = cadastrarFuncionario.Papel;


        var permissao = _context.TipoPermissaos.Find(cadastrarFuncionario.Permissao);
        cadastrarFuncionario.Funcionario.Permissao = permissao;
        cadastrarFuncionario.Funcionario.PermissaoId = cadastrarFuncionario.Permissao;

        _context.Add(cadastrarFuncionario.Funcionario);
        await _context.SaveChangesAsync();


        return View();
    }



}
