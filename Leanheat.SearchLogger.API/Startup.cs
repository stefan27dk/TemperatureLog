using GreenPipes;
using Leanheat.SearchLogger.Application.Interfaces;
using Leanheat.SearchLogger.Application.Interfaces.Infrastructure;
using Leanheat.SearchLogger.Application.Services;
using Leanheat.SearchLogger.Application.Services.RabitMq;
using Leanheat.SearchLogger.MongoDB;
using Leanheat.SearchLogger.MongoDB.Models;
using MassTransit;
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

namespace Leanheat.SearchLogger.API
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
        public void ConfigureServices(IServiceCollection services)// This method gets called by the runtime. Use this method to add services to the container.
        {
            services.AddMvc();

            // MongoDB - Config - Connectionstring-------------------------------------------------------------
            services.Configure<SearchLogDbConfig>(
                options =>
                {
                    options.Connection_String = Configuration.GetSection("ConnectionStrings:MongoDbContext").Value;
                    options.Database_Name = Configuration.GetSection("ConnectionStrings").Value;
                });

            //Inject the client using dependency injection
            //One instance of the client through the application
            services.AddSingleton<IDbClient, DbClient>();
            services.Configure<SearchLogDbConfig>(Configuration);



            // CORS
            services.AddCors();

            

            // Services
            services.AddTransient<ISearchLoggerService, SearchLoggerService>();



            // RABIT MQ
            services.AddMassTransit(x =>
            {
                x.AddConsumer<SearchLogConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri("rabbitmq://192.168.99.100"), h =>
                    {
                        h.Username("user123");
                        h.Password("user123");
                    });


                    cfg.ReceiveEndpoint("searchLogQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<SearchLogConsumer>(provider);
                    });
                }));
            });
            services.AddMassTransitHostedService();




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Leanheat.SearchLogger.API", Version = "v1" });
            });
        }







        // Configure ===========================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leanheat.SearchLogger.API v1"));
            }

            // Https
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRouting();

           
            // CORS - Allow calling the API from WebBrowsers
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
                .SetIsOriginAllowed(origin => true));// Allow any origin  


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
