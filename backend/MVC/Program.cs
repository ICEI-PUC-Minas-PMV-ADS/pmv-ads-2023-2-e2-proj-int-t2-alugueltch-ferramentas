using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Controllers;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddEntityFrameworkNpgsql()
                      .AddDbContext<ATDBContext>(options =>
                        options.UseNpgsql("Host=atdb-pg.postgres.database.azure.com;Port=5432;Database=atdb;User ID=vitor@atdb-pg;Password=puc123;"));

                        builder.Services.AddEndpointsApiExplorer();

                        builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

                        if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                        app.MapFerramentumEndpoints();

            app.Run();
        }
    }
}