using Leanheat.Spa.Server.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.Application.Services.Identity
{
    public class IdentityAccountService : IIdentityAccountService
    {

        // Register ======================================================================================================== 
        public Task<IActionResult> Register(string firstname, string lastname, string email, string age, string phonenumber, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }



        // Log In ==========================================================================================================
        public Task<IActionResult> LogIn(string email, string password, bool rememberMe)                                    
        {                                                                                                                   
            throw new NotImplementedException();                                                                            
        }                                                                                                                   
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
        // Log Out =========================================================================================================
        public Task<IActionResult> LogOut()                                                                                 
        {                                                                                                                   
            throw new NotImplementedException();                                                                            
        }                                                                                                                   
                                                                                                                            
                                                                                                                                                                       
                                                                                                                                                                       
                                                                                                                                                                       
        // Get User Data ===================================================================================================                                           
        public Task<IActionResult> GetUserData()                                                                                                                       
        {                                                                                                                                                              
            throw new NotImplementedException();                                                                                                                       
        }                                                                                                                                                              
                                                                                                                                                                       
                                                                                                                                                                       
                                                                                                                                                                       
                                                                                                                                                                       
        // Get User Email - Used to check if user is logged in =============================================================
        public Task<IActionResult> GetUserEmail()                                                                           
        {                                                                                                                   
            throw new NotImplementedException();                                                                            
        }                                                                                                                   
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
        // Delete LogIn ====================================================================================================
        public Task<IActionResult> DeleteLogIn(string email)
        {
            throw new NotImplementedException();
        }





 


  



        
        
   


        // Update User =========================================================================================================
        public Task<IActionResult> UpdateUser(string firstName, string lastName, string email, string age, string phonenumber, string password)
        {
            throw new NotImplementedException();
        }
    }
}
