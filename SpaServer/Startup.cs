using Leanheat.Spa.Server.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leanheat.Spa.Server.Application.Services.IdentityServices.ApplicationUserServices;

namespace SpaServer
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
        public void ConfigureServices(IServiceCollection services) // This method gets called by the runtime. Use this method to add services to the container.
        {

            // Services
            services.AddScoped<IApplicationUserService, ApplicationUserService>();



            // Base Adresses Identity
            services.AddHttpClient("IdentityAPI", e =>
            {
                e.BaseAddress = new Uri("https://localhost:44347/");
                // Versioning
                //e.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpaServer", Version = "v1" });
            });
        }









        // Configure ===========================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpaServer v1"));
            }

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
