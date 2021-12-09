using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OficinaWeb.Infra.Repositories.Context;
using OficinaWeb.Infra.Repositories.Abstractions;
using OficinaWeb.Infra.Repositories.Repositories;
using OficinaWeb.API.AutoMapper;

namespace OficinaWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //adicionando o context e string de conexao
            services.AddDbContext<OficinaWebContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            //razor adicionado manualmente
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //adicionando o automapper
            services.AddAutoMapper(typeof(AutoMapperSetup));

            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
