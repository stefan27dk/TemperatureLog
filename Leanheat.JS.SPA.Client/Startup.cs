using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.JS.SPA.Client
{     
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // Startup
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // Configure Services ================================================================================= 
        public void ConfigureServices(IServiceCollection services) // This method gets called by the runtime. Use this method to add services to the container.         // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        {
        }


        // Configure ===========================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            // Dev - Mode
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // SPA
            app.UseDefaultFiles(); // Means search for the index.html or default files in wwwroot - 
            app.UseStaticFiles(); // Static files are files in the wwwroot - Use wwwroot files


            // Https
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();

            // Endpoints
            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>    // Route to the index.html if 404 Error and for SPA it always routes to index because SPA is single page APP.  // The url routing is done on CLient side 
                {
                    endpoints.MapFallbackToFile("/index.html");
                });
            });
        }
    }
}
