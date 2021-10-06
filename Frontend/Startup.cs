using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistencia;
using Dominio;

namespace Frontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            //Registrar el contexto de datos
            services.AddDbContext<Persistencia.AppContext>();
            //Inyeccion de dependencia para municipio
            services.AddScoped<IRepositorioMunicipio, RepositorioMunicipio>();
            //Inyeccion de dependencia para deportista
            services.AddScoped<IRepositorioDeportista, RepositorioDeportista>();
            //Inyeccion de dependencia para patrocinador
            services.AddScoped<IRepositorioPatrocinador, RepositorioPatrocinador>();
            //Inyeccion de dependencia para equipo
            services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            //Inyeccion de dependencia para escuelaArbitro
            services.AddScoped<IRepositorioEscuelaArbitro, RepositorioEscuelaArbitro>();
            //Inyeccion de dependencia para arbitro
            services.AddScoped<IRepositorioArbitro, RepositorioArbitro>();
            //Inyeccion de dependencia para entrenador
            services.AddScoped<IRepositorioEntrenador, RepositorioEntrenador>();
            //Inyeccion de dependencia para escenario
            services.AddScoped<IRepositorioEscenario, RepositorioEscenario>();
            //Inyeccion de dependencia para canchaEspacio
            services.AddScoped<IRepositorioCanchaEspacio, RepositorioCanchaEspacio>();
            //Inyeccion de dependencia para Torneo
            services.AddScoped<IRepositorioTorneo, RepositorioTorneo>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
