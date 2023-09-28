using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Models
{
    public partial class Ferramentum
    {
        public Ferramentum()
        {
            Emprestimos = new HashSet<Emprestimo>();
            Orcamentos = new HashSet<Orcamento>();
            Processos = new HashSet<Processo>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public long TipoId { get; set; }
        public string Marca { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public long SituacaoId { get; set; }
        public string CadastradoPor { get; set; } = null!;
        public decimal ValorDiaria { get; set; }
        public decimal ValorCompra { get; set; }

        public virtual TipoSituacao Situacao { get; set; } = null!;
        public virtual TipoFerramentum Tipo { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }
    }


public static class FerramentumEndpoints
{
	public static void MapFerramentumEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Ferramentum", async (ATDBContext db) =>
        {
            return await db.Ferramenta.ToListAsync();
        })
        .WithName("GetAllFerramentums")
        .Produces<List<Ferramentum>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Ferramentum/{id}", async (long Id, ATDBContext db) =>
        {
            return await db.Ferramenta.FindAsync(Id)
                is Ferramentum model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetFerramentumById")
        .Produces<Ferramentum>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Ferramentum/{id}", async (long Id, Ferramentum ferramentum, ATDBContext db) =>
        {
            var foundModel = await db.Ferramenta.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(ferramentum);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateFerramentum")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Ferramentum/", async (Ferramentum ferramentum, ATDBContext db) =>
        {
            db.Ferramenta.Add(ferramentum);
            await db.SaveChangesAsync();
            return Results.Created($"/Ferramentums/{ferramentum.Id}", ferramentum);
        })
        .WithName("CreateFerramentum")
        .Produces<Ferramentum>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Ferramentum/{id}", async (long Id, ATDBContext db) =>
        {
            if (await db.Ferramenta.FindAsync(Id) is Ferramentum ferramentum)
            {
                db.Ferramenta.Remove(ferramentum);
                await db.SaveChangesAsync();
                return Results.Ok(ferramentum);
            }

            return Results.NotFound();
        })
        .WithName("DeleteFerramentum")
        .Produces<Ferramentum>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
