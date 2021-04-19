using Leanheat.Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Identity.API.Controllers
{

    // Class ============= || Administrator - Controller ||==========================================
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {

        // Managers
        private readonly RoleManager<IdentityRole> roleManager; // RoleManager
        private readonly UserManager<ApplicationUser> userManager; // User Manager





        // || Constructor || ====================================================================
        public AdministratorController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }








        // ===== Create Role =====================================================================
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (roleName != null)
            {
                IdentityRole identityRole = new IdentityRole { Name = roleName }; // Set New Role
                var result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)// If OK
                {
                    return StatusCode(200, "Role Created Successfully");
                }
                return StatusCode(409, result.Errors);
            }
            return StatusCode(409, "Input was null - Cant create Role without rolename");
        }











        // ===== Get All Roles =====================================================================
        [HttpGet]
        [Route("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = roleManager.Roles;
            return new JsonResult(roles);
        }




    }
}
