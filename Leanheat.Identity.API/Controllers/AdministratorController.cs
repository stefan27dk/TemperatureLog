using Leanheat.Identity.API.DBContexts;
using Leanheat.Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly LeanheatIdentityApiContext identityDBContext; // Db Context





        // || Constructor || ====================================================================
        public AdministratorController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, 
            LeanheatIdentityApiContext identityDBContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.identityDBContext = identityDBContext;
        }









        // ===== Create Role || POST || =====================================================================
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
                return StatusCode(500, result.Errors);
            }
            return StatusCode(409, "Input was null - Cant create Role without rolename");
        }














        // ===== Get All Roles  || GET || =====================================================================
        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
           return await Task.Run(() =>
           {
               var roles = roleManager.Roles;
               return new JsonResult(roles);
           });
        }













        // ===== Edit Role - || Post || =====================================================================
        [HttpPost]
        [Route("EditRole")]
        public async Task<IActionResult> EditRole(string oldName, string newName)
        {
            // Find Role
            var role = await roleManager.FindByNameAsync(oldName);
            if(role != null) // If found
            {     
                role.Name = newName; // Change name
                var result = await roleManager.UpdateAsync(role); // Update

                if (result.Succeeded) // If Update OK
                {
                    return StatusCode(200, "Role Updated Successfully");
                }
                return StatusCode(500, result.Errors);  // If Update Error
            }
            else // If no such Role
            {
                return StatusCode(404, "No such role");
            }
        }












        // ===== Remove Role - || Post || =====================================================================
         [HttpPost]
         [Route("RemoveRole")]
         public async Task<IActionResult> RemoveRole(string roleName, string reAssignRole)
         {
            var role = await roleManager.FindByNameAsync(roleName); // Find the role
            if(role != null)
            {
                var roleToDelete = await roleManager.FindByNameAsync(roleName); // Get the role
                var usersInRole = await userManager.GetUsersInRoleAsync(roleName); // Get List of user in the Role

                     // Reassign Users to another role----------------------------------------------------------
                    if (usersInRole != null && reAssignRole != null) // If there are users in the role and added role for reassigning the users
                    {
                        var roleToReAssign = await roleManager.FindByNameAsync(reAssignRole); // Get the role for reassigning
                        if(roleToReAssign != null) // If reassigning role exists
                        {
                            List<ApplicationUser> rollbackList = new List<ApplicationUser>(); // Rollback list if erors
                            IdentityResult changeRoleResult;


                            for (int i = 0; i < usersInRole.Count; i++) // Loop and reassign users
                            {
                               changeRoleResult = await userManager.AddToRoleAsync(usersInRole[i], reAssignRole);
                               if(changeRoleResult.Succeeded)
                               {
                                 rollbackList.Add(usersInRole[i]);
                               }


                               else // If cant reassign users
                               {

                                   if(rollbackList.Count != 0)  // If list not empty Rollback
                                   {
                                      for (int k = 0; k < rollbackList.Count; k++)
                                      {
                                        await userManager.AddToRoleAsync(rollbackList[k], roleName);  // Rollback
                                      }
                                   }
                                   return StatusCode(500, "Fatal error: could not reassign one or more of the users - Please try again"); // If list empty return just message
                               }

                            }
                        }
                        else
                        {
                           return StatusCode(404, $"The Role: \"{reAssignRole}\" for reassigning the users cant be found");
                        }
                    }
                     
                


                        // Delete the Role-----------------------------------------------------------------------
                        var result = await roleManager.DeleteAsync(roleToDelete); // Delete Role
                        if(result.Succeeded) // If Ok
                        {
                           return StatusCode(200, $"Role: \"{roleName} \" was Successfully Deleted");  // Role Deleted msg
                        }
                           return StatusCode(500, result.Errors); // Delete Errors
                    
            }
            return StatusCode(401,"Role not found"); // Role not found msg

         }














        // ===== Remove Role from User - || Post || =====================================================================
         [HttpPost]
         [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveRoleFromUser(string email, string roleName)
         {
            var user = await userManager.FindByEmailAsync(email);  // Get User
            if (user != null) // If user found
            {
                var role = await roleManager.FindByNameAsync(roleName); // Get Role
                if(role != null) // If role found
                {
                    var result = await userManager.RemoveFromRoleAsync(user,roleName); // Remove User from Role
                    if(result.Succeeded) // If Ok
                    {
                        return StatusCode(200, $"User: \"{user.Email}\" was removed from Role: \" {roleName} \" "); // Remove User from Role msg
                    }
                    return StatusCode(500, result.Errors); // If Remove User from role error
                }
                return StatusCode(404, "No such Role"); // If Role not found msg
            }
            return StatusCode(404, "No such User"); // If User not found msg
         }














        // ===== AddUserToRole- || Post || =====================================================================
        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> EditUserInRole(string userEmail, string roleName)
        {
            var user = await userManager.FindByEmailAsync(userEmail); // Find user
            if (user != null)
            {
                var role = await roleManager.FindByNameAsync(roleName); // Find role
                if (role != null)
                {
                    if (!await userManager.IsInRoleAsync(user, roleName)) // If user is not in that role
                    {
                        var result = await userManager.AddToRoleAsync(user, roleName);  // Add the user to the ROLE
                        if (result.Succeeded)
                        {
                            return StatusCode(200, $"The user was Successfully added to the Role: - \"{roleName}\" ");
                        }
                    }
                    return StatusCode(200, "The User is already member of that role"); // Already memeber of that role msg
                }
                return StatusCode(404, "Role not found");  // Role not found
            }
            return StatusCode(404, "User not found"); // User not found
        }














        // ===== Get ALL Users - || GET || =====================================================================
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
              var users = await userManager.Users.ToListAsync();
              return  StatusCode(200, users); // Get all users
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }












        // ===== Get User - || GET || =====================================================================
        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user != null)
            {
                return StatusCode(200, user); // Get user
            }
            return StatusCode(404, "No such user"); // Get user

        }











        // ===== Get Users with Roles - || GET || =====================================================================
        [HttpGet]
        [Route("GetAllUsersWithRoles")]
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            try
            {
                      return await Task.Run(() => 
                      { 
                         var users =  identityDBContext.UserRoles;
                         return StatusCode(200, users); // Get all users
                      });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}
