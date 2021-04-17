using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Identity.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        // ==== [Firstname] =============================================================================  
        public string FirstName { get; set; }



        // ==== [Lastname] ================================================================================  
        public string LastName { get; set; }



        // ==== [Age] ======================================================================================  
        public int Age { get; set; }

    }
}
