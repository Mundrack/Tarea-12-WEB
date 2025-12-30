using Best_Practices.Infraestructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Este método es llamado por el runtime para agregar servicios al contenedor.
        /// MEJORA: Ahora pasa la configuración a ServicesConfiguration para implementar Strategy Pattern.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            var dependencyInjection = new ServicesConfiguration();
            services.AddControllersWithViews();

            // MEJORA: Pasar Configuration para que ServicesConfiguration pueda leer appsettings.json
            dependencyInjection.ConfigureServices(services, Configuration);
        }

        /// <summary>
        /// Este método es llamado por el runtime para configurar el pipeline de peticiones HTTP.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}