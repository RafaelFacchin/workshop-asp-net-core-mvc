using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace S18_SalesWeb_MVC
{
    public class Startup
    {
        //***CONSTRUTOR
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //****METODO
        //Metodo RUNTIME: use este metodo para comfigurar pos servicos da aplicacao
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // Esta funcao LAMBDA determina
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        //****Metodo para configuracao
        //Tambem conhecido como PIPELINE HTTP (filtro de requisicoes)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            //CONFIGURACAO BASICA DE ROTAS
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controleer=Home}/{action=Index}/{id?}");
            });
        }
    }
}
