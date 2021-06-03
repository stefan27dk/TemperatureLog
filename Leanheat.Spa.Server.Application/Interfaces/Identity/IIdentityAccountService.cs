using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.Application.Interfaces.Identity
{
    public interface IIdentityAccountService
    {


        // Register ============================================================================================================== 
        /// <summary>
        ///
        /// </summary>
        public Task<IActionResult> Register(string firstname, string lastname, string email, string age, string phonenumber, string password, bool rememberMe);



        // Log In =============================================================================================================== 
        public Task<IActionResult> LogIn(string email, string password, bool rememberMe);


        // Log Out ==============================================================================================================
        public Task<IActionResult> LogOut();


        // Get User Data ============================================================================================================ 
        public Task<IActionResult> GetUserData();



        // Get User Email - Used to check if user is logged in ================================================================= 
        public Task<IActionResult> GetUserEmail();



        // Update User =========================================================================================================
        public Task<IActionResult> UpdateUser(string firstName, string lastName, string email, string age, string phonenumber, string password);



        // Delete LogIn ========================================================================================================
        public Task<IActionResult> DeleteLogIn(string email);

    }
}
