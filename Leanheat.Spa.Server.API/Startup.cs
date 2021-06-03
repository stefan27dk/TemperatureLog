using Leanheat.Spa.Server.Application.Interfaces.Identity;
using Leanheat.Spa.Server.Application.Interfaces.TemperaturePrediction;
using Leanheat.Spa.Server.Application.Services.Identity;
using Leanheat.Spa.Server.Application.Services.TemperaturePrediction;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.API
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
        public void ConfigureServices(IServiceCollection services)// This method gets called by the runtime. Use this method to add services to the container.
        {
            // Services
            services.AddTransient<IIdentityAccountService, IdentityAccountService>();
            services.AddTransient<ITemperaturePredictionService, TemperaturePredictionService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            
            // CORS
            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Leanheat.Spa.Server.API", Version = "v1" });
            });


            // Cookie
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();




            //// Log In
            //// Make all Controllers protected by default so only Authorized Users can accsess them, for Anonymouse Users use [AlloAnonymouse] over the controllers.
            //services.AddMvc(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //      .RequireAuthenticatedUser()
            //      .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));

            //}).AddXmlSerializerFormatters();
        }





        // Configure ===========================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leanheat.Spa.Server.API v1"));
            }


            // HTTPS
            app.UseHsts(); // Allow HTTPS
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
