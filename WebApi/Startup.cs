using BusinessLogic.Data;
using BusinessLogic.Logica;
using Core.Interfases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApi.Middleware;

namespace WebApi
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
            //Conexion al motor SQL
            services.AddDbContext<DesarmarketDbContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Mapper
            services.AddAutoMapper(typeof(MappingProfiles));

            //Instancia de GenericRepo
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



            //Instancia para repositorio particular
            services.AddTransient<IArticulosStockRepository, ArticulosStockRepository>();
            //services.AddRazorPages();
            services.AddControllers();

            //CORS
            services.AddCors(opt => {
                opt.AddPolicy("CorsRule", rule => rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors","?code={0}");

            //app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsRule");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
