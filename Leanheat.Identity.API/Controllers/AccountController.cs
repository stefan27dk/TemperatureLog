using Leanheat.Identity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leanheat.Identity.API.Controllers
{
    
    // Class ============= || Account - Controller ||==========================================
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
        public async Task<IActionResult> Register(string firstname, string lastname, string email, string age, string phonenumber, string password, bool rememberMe)
        {
            //var user = new ApplicationUser { UserName = email, Email = email };  // Create the User
            var user = new ApplicationUser(); // Create the User
            var setResult = user.SetUserData(firstname, lastname, email, age, phonenumber, password); ;

            if(setResult.Succeeded) // If all validated
            {
                if (email != null && password != null) 
                {
                      var result = await userManager.CreateAsync(user); // Save the  User
                      if (result.Succeeded)  // If All Ok
                      {
                          await signInManager.SignInAsync(user, isPersistent: rememberMe);  // Sign In the User "Session with persistent cookie"
                          return StatusCode(200, "Registration Successfull");
                      }
                      return StatusCode(409, result.Errors);  // Create User Errors
                }
                return StatusCode(409, "Email or Password is empty"); // Registration Errors
            }
            return StatusCode(409, setResult);  // Validation Errors
        }










        // Log In ===================================================================================
        [HttpPost]
        [Route("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(string email, string password, bool rememberMe)
        {
            if(email != null && password !=null)
            {
                var result = await signInManager.PasswordSignInAsync(email, password, rememberMe, false);
                if (result.Succeeded) // If Login Ok
                {
                    return new JsonResult(result);
                }
                return StatusCode(401, "Invalid Log In");  // If Erors return errors 
            }
            return StatusCode(401, "Email or Password cant be empty");
        }






        // Log Out ==================================================================================
        [HttpPost]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return StatusCode(200, "Successfully Logged Out");
        }






        // Get User  ==================================================================================
        [HttpGet]
        [Route("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            // Get Current User
            var user = await userManager.GetUserAsync(HttpContext.User);
            return new JsonResult(user);
        }













        // Update User ==================================================================================
        [HttpPost]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string firstName, string lastName, string email, string age, string phonenumber, string password)
        {
            // Get Current User
            var user = await userManager.GetUserAsync(HttpContext.User);


            // Set User data with validation
            var validationResult = user.SetUserData(firstName, lastName, email, age,  phonenumber, password);


            // Update
            if(validationResult.Succeeded) // Update if validation passed
            {
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)// If OK
                {
                    return StatusCode(200, "User Data Updated Successfully");
                }
                else  // If Update Error
                {
                    return StatusCode(409, result.Errors);
                }
            }
            else // If validation Error
            {
                return StatusCode(409, validationResult);
            }
        }







        //// Update User ==================================================================================
        //[HttpPost]
        //[Route("UpdateUser")]
        //public async Task<IActionResult> UpdateUser(string email, string firstName, string lastName, int age, string password, string tel)
        //{
        //    // Get Current User
        //    var user = await userManager.GetUserAsync(HttpContext.User);


        //    // Update only if values are not null
        //    if (firstName != null) { user.FirstName = firstName; }
        //    if (lastName != null) { user.LastName = lastName; }


        //    // Email
        //    if (Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))  // Email Regex
        //    {
        //        user.Email = email;
        //        user.UserName = email;
        //        user.NormalizedUserName = email.ToUpper();
        //        user.NormalizedEmail = email.ToUpper();
        //    }
        //    else
        //    {
        //        return StatusCode(422, "Email is not valid"); // Email Error
        //    }



        //    if (tel != null) { user.PhoneNumber = tel; }
        //    if (age != 0) { user.Age = age; }



        //    // Password
        //    if (password != null)
        //    {
        //        var passwordHasher = new PasswordHasher<ApplicationUser>();
        //        var newHashedPassword = passwordHasher.HashPassword(user, password);
        //        user.PasswordHash = newHashedPassword;
        //    }




        //    // Update
        //    var result = await userManager.UpdateAsync(user);





        //    if (result.Succeeded)// If OK
        //    {
        //        return StatusCode(200, "User Data Updated Successfully");
        //    }
        //    else  // If Error
        //    {
        //        return new JsonResult(result.Errors);
        //    }
        //}


















        //// Update Password ==================================================================================
        //[HttpPost]
        //[Route("UpdatePassword")]
        //public async Task<IActionResult> UpdatePassword(string newPassword)
        //{
        //    // Get Current User
        //    var user = await userManager.GetUserAsync(HttpContext.User);



        //    // Change Password
        //    if (!await userManager.CheckPasswordAsync(user, newPassword))
        //    {
        //        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        //        await userManager.ResetPasswordAsync(user, token, newPassword);
        //        return StatusCode(200, "Password Updated Successfully");
        //    }
        //    else // If password is the same as the old
        //    {
        //        return StatusCode(409, "Please enter different password from the old");
        //    }
        //}








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

                
                if(result.Succeeded)// If Success
                {
                    return StatusCode(200, "User Deleted Successfully");
                }
                else// If Error
                {
                    return new JsonResult(result.Errors);
                }
            }
            else// If email not same as the users email
            {
                return StatusCode(422, "Please enter your email to confirm deletion of the account");
            }
        }



    }
}
