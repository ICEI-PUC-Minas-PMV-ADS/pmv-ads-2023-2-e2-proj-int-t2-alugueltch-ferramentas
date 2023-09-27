using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WEBAPI.Models;

namespace WEBAPI.Models
{
    public partial class TipoFerramentum
    {
        public TipoFerramentum()
        {
            Ferramenta = new HashSet<Ferramentum>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
    }


public static class TipoFerramentumEndpoints
{
	public static void MapTipoFerramentumEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/TipoFerramentum", async (ATDBContext db) =>
        {
            return await db.TipoFerramenta.ToListAsync();
        })
        .WithName("GetAllTipoFerramentums")
        .Produces<List<TipoFerramentum>>(StatusCodes.Status200OK);

        routes.MapGet("/api/TipoFerramentum/{id}", async (long Id, ATDBContext db) =>
        {
            return await db.TipoFerramenta.FindAsync(Id)
                is TipoFerramentum model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetTipoFerramentumById")
        .Produces<TipoFerramentum>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/TipoFerramentum/{id}", async (long Id, TipoFerramentum tipoFerramentum, ATDBContext db) =>
        {
            var foundModel = await db.TipoFerramenta.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(tipoFerramentum);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateTipoFerramentum")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/TipoFerramentum/", async (TipoFerramentum tipoFerramentum, ATDBContext db) =>
        {
            db.TipoFerramenta.Add(tipoFerramentum);
            await db.SaveChangesAsync();
            return Results.Created($"/TipoFerramentums/{tipoFerramentum.Id}", tipoFerramentum);
        })
        .WithName("CreateTipoFerramentum")
        .Produces<TipoFerramentum>(StatusCodes.Status201Created);


        routes.MapDelete("/api/TipoFerramentum/{id}", async (long Id, ATDBContext db) =>
        {
            if (await db.TipoFerramenta.FindAsync(Id) is TipoFerramentum tipoFerramentum)
            {
                db.TipoFerramenta.Remove(tipoFerramentum);
                await db.SaveChangesAsync();
                return Results.Ok(tipoFerramentum);
            }

            return Results.NotFound();
        })
        .WithName("DeleteTipoFerramentum")
        .Produces<TipoFerramentum>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
