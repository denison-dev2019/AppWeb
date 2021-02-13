using AppWeb.Configurations;
using AppWeb.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb
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
            services.AddMvcConfiguration();
            services.ResolveDependencies();
            services.AddControllersWithViews();
            services.AddSession();
            services.Configure<ApplicationSettings>(Configuration.GetSection("Configuracoes"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAutoMapperCustomizado();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddRouting(options => { options.LowercaseUrls = true; });
            services.AddRazorPages().AddRazorRuntimeCompilation();
             services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseCors(builder =>
                   builder.AllowAnyHeader()
               );
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.AddMvcUseConfiguration();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );

            });
        }
    }
}
