using Leanheat.Blazor.Server.Application.Interfaces;
using Leanheat.Blazor.Server.Application.Services.IdentityServices.ApplicationUserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Leanheat.Blazor.Server
{
    public class Startup
    {
        // Startup
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }





        // Configure Services ================================================================================= 
        public void ConfigureServices(IServiceCollection services) // This method gets called by the runtime. Use this method to add services to the container.// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            // Services
            services.AddScoped<IApplicationUserService, ApplicationUserService>();



            // Base Adresses
            services.AddHttpClient("IdentityAPI", e =>
            {
                e.BaseAddress = new Uri("https://localhost:44347/");
                // Versioning
                //e.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            });
        }




        // Configure ===========================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
