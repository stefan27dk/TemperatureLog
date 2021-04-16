using Leanheat.Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Identity.API
{
    public class LeanheatIdentityApiContext : IdentityDbContext<ApplicationUser>
    {

        public LeanheatIdentityApiContext(DbContextOptions<LeanheatIdentityApiContext> options)
         : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Ignore these so they dont come in to the db
            //builder.Entity<ApplicationUser>().Ignore(c => c.UserName);
            //builder.Entity<ApplicationUser>().Ignore(c => c.NormalizedUserName);
            //builder.Entity<ApplicationUser>().Ignore(c => c.NormalizedEmail);
     
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        //public DbSet<ApplicationUser> FirstName { get; set; }
        //public DbSet<ApplicationUser> LastName { get; set; }
        //public DbSet<ApplicationUser> Age { get; set; }


    }
}
