using Leanheat.Identity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Identity.API.Controllers
{
    // Acount - Controller - || Class ||
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        // Managers
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;



        // || Constructor || ====================================================================
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }






        // Register ========================================================================== 
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string email, string password, bool rememberMe)
        {
            var user = new ApplicationUser { UserName = email, Email = email };  // Create the User
            var result = await userManager.CreateAsync(user, password);

            // If All Ok
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: rememberMe);  // Sign In the User "Session with persistent cookie"
                return StatusCode(200, "Registration Successfull");
            }

            // If Erors return errors 
            //return new JsonResult(result.Errors);
            return StatusCode(409, result.Errors);

        }






        // Log In ===================================================================================
        [HttpPost]
        [Route("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(string email, string password, bool rememberMe)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, rememberMe, false);

            if (result.Succeeded) // If Login Ok
            {
                //return StatusCode(200);
                return new JsonResult(result);
            }

            // If Erors return errors 
            return StatusCode(401, "Invalid Log In");
        }






        // Log Out ==================================================================================
        [HttpPost]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return StatusCode(200, "Successfully Logged Out");
        }






        // GetUser LogIn ==================================================================================
        [HttpGet]
        [Route("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            // Get Current User
            var user = await userManager.GetUserAsync(HttpContext.User);
            return new JsonResult(user);
        }













        // Update Email ==================================================================================
        [HttpPost]
        [Route("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail(string email)
        {
            // Get Current User
            var user = await userManager.GetUserAsync(HttpContext.User);



            // Change Email
            var result = await userManager.SetEmailAsync(user, email);  

            // If Ok
            if (result.Succeeded)
            {
                return StatusCode(200, "Email Updated Successfully");
            }
            else
            {
                return new JsonResult(result.Errors);
            }

        }




        // Update Password ==================================================================================
        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(string newPassword)
        {
            // Get Current User
            var user = await userManager.GetUserAsync(HttpContext.User);

              

            // Change Password
            if (!await userManager.CheckPasswordAsync(user, newPassword))
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                await userManager.ResetPasswordAsync(user, token, newPassword);
                return StatusCode(200, "Password Updated Successfully");
            }
            else // If password is the same as the old
            {
                return StatusCode(409, "Please enter different password from the old");
            }
        }








        // Delete LogIn ==================================================================================
        [HttpPost]
        [Route("DeleteLogIn")]
        public  async Task<IActionResult> DeleteLogIn(string email)
        {
            // Get Current User
            var user = await userManager.GetUserAsync(HttpContext.User); 

            if(user.Email == email)
            {
                // Delete the User
                var result = await userManager.DeleteAsync(user);

                // If Success
                if(result.Succeeded)
                {
                    return StatusCode(200, "User Deleted Successfully");
                }

                // If Error
                else
                {
                    return new JsonResult(result.Errors);
                }
            }

            // If email not same as the users email
            else
            {
                return StatusCode(422, "Please enter your email to confirm deletion of the account");
            }
        }



    }
}
