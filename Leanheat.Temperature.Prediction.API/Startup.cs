
using Leanheat.Temperature.Prediction.API.Application.Interfaces;
using Leanheat.Temperature.Prediction.API.Application.Services;
using Leanheat.Temperature.Prediction.API.MongoDB;
using Leanheat.Temperature.Prediction.API.MongoDB.Interfaces;
using Leanheat.Temperature.Prediction.API.MongoDB.Models;
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

namespace Leanheat.Temperature.Prediction.API
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
        public void ConfigureServices(IServiceCollection services)  // This method gets called by the runtime. Use this method to add services to the container.
        {
            services.AddMvc();

            // MongoDB - Config - Connectionstring-------------------------------------------------------------
            services.Configure<TempDbConfig>(
                options =>
                {
                    options.Connection_String = Configuration.GetSection("ConnectionStrings:MongoDbContext").Value;
                    options.Database_Name = Configuration.GetSection("ConnectionStrings").Value;
                });

            //Inject the client using dependency injection
            //One instance of the client through the application
            services.AddSingleton<IDbClient, DbClient>();
            services.Configure<TempDbConfig>(Configuration);


            // Services
            services.AddTransient<ITempServices, TempServices>();


            //  Default Services -------------------------------------------------------------------------------
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Leanheat.Temperature.Prediction.API", Version = "v1" });
            });
        }







        // Configure ===========================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leanheat.Temperature.Prediction.API v1"));
            }


            // Https
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
