using Leanheat.Identity.API.DBContexts;
using Leanheat.Identity.API.Filters;
using Leanheat.Identity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Identity.API
{

    // Startup
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }






        // Configure Services ================================================================================= 
        public void ConfigureServices(IServiceCollection services)// This method gets called by the runtime. Use this method to add services to the container.
        {


            // Log in - DbContext
            services.AddDbContextPool<LeanheatIdentityApiContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityContextConnection")));


            // UnitOfWork - Filter
            services.AddScoped<UnitOfWorkFilter>(); 
            services.AddControllers(config => { config.Filters.AddService<UnitOfWorkFilter>(); });  // UnitOfWork for all Controllers



            // Log In
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

            }).AddEntityFrameworkStores<LeanheatIdentityApiContext>().AddDefaultTokenProviders(); // AddDefaultTokenProviders is used for the Update Log In Password etc.







            // Log In
            // Make all Controllers protected by default so only Authorized Users can accsess them, for Anonymouse Users use [AlloAnonymouse] over the controllers.
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
                options.Filters.Add(new AuthorizeFilter(policy));

            }).AddXmlSerializerFormatters();

            //services.AddControllers();






            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Leanheat.Identity.API", Version = "v1" });
            });
        }









        // Configure ===========================================================================================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            // Default Code------------------------------------------------------------------------------------>
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leanheat.Identity.API v1"));
            }

           
            app.UseHsts(); // Allow HTTPS
            app.UseHttpsRedirection();
            app.UseRouting();


            // Log In
            app.UseAuthorization();
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
