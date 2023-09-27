using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WEBAPI.Models;

namespace WEBAPI.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Emprestimos = new HashSet<Emprestimo>();
            Orcamentos = new HashSet<Orcamento>();
        }

        public long Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public char Sexo { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public long EnderecoId { get; set; }
        public short IndicadorDivida { get; set; }

        public virtual Endereco Endereco { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
    }


public static class ClienteEndpoints
{
	public static void MapClienteEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Cliente", async (ATDBContext db) =>
        {
            return await db.Clientes.ToListAsync();
        })
        .WithName("GetAllClientes")
        .Produces<List<Cliente>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Cliente/{id}", async (long Id, ATDBContext db) =>
        {
            return await db.Clientes.FindAsync(Id)
                is Cliente model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetClienteById")
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Cliente/{id}", async (long Id, Cliente cliente, ATDBContext db) =>
        {
            var foundModel = await db.Clientes.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(cliente);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCliente")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Cliente/", async (Cliente cliente, ATDBContext db) =>
        {
            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();
            return Results.Created($"/Clientes/{cliente.Id}", cliente);
        })
        .WithName("CreateCliente")
        .Produces<Cliente>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Cliente/{id}", async (long Id, ATDBContext db) =>
        {
            if (await db.Clientes.FindAsync(Id) is Cliente cliente)
            {
                db.Clientes.Remove(cliente);
                await db.SaveChangesAsync();
                return Results.Ok(cliente);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCliente")
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
