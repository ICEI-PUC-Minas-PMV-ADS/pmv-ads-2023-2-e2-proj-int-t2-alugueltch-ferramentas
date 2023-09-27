using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;
using WEBAPI.Controllers;

namespace WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEntityFrameworkNpgsql()
                       .AddDbContext<ATDBContext>(options =>
                         options.UseNpgsql("Host=localhost;Port=5432;Database=ATDB;User ID=postgres;Password=142815;"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                        if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

                        app.MapClienteEndpoints();

                        app.MapTipoFerramentumEndpoints();

            app.Run();
        }
    }
}