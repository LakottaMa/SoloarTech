using SoloarTech.Components;
using Microsoft.EntityFrameworkCore;
using SolarTech.Data;

namespace SoloarTech
    {
    public static class Program
        {
        public static void Main(string[] args)
            {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            // Add the database context to the container
            builder.Services.AddDbContext<SolarTechDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SolarTechDBContext")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment())
                {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
            }
        }
    }
