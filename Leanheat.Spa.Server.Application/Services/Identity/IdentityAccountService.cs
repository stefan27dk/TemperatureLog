using Leanheat.Spa.Server.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http;
 

namespace Leanheat.Spa.Server.Application.Services.Identity
{
    public class IdentityAccountService : IIdentityAccountService
    {
        private static readonly HttpClient client = new HttpClient();


        // Constructor
        public IdentityAccountService()
        {

        }


        // Register ======================================================================================================== 
        public async Task<IActionResult> Register(string firstname, string lastname, string email, string age, string phonenumber, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }



        // Log In ==========================================================================================================
        public async Task<object> LogIn(string email, string password, bool rememberMe)                                    
        {
           
            //var content = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");
          
            var response =  await client.PostAsync($"https://localhost:44347/Account/LogIn?email={email}&password={password}&rememberMe={rememberMe}", null);
            return response; 
            //"https://localhost:44347/Account/LogIn?email=a%40a.dk&password=123456&rememberMe=true"
        }




        // Log Out =========================================================================================================
        public async Task<IActionResult> LogOut()                                                                                 
        {                                                                                                                   
            throw new NotImplementedException();                                                                            
        }                                                                                                                   
                                                                                                                            
                                                                                                                                                                       
                                                                                                                                                                       
                                                                                                                                                                       
        // Get User Data ===================================================================================================                                           
        public async Task<IActionResult> GetUserData()                                                                                                                       
        {                                                                                                                                                              
            throw new NotImplementedException();                                                                                                                       
        }                                                                                                                                                              
                                                                                                                                                                       
                                                                                                                                                                       
                                                                                                                                                                       
                                                                                                                                                                       
        // Get User Email - Used to check if user is logged in =============================================================
        public async Task<IActionResult> GetUserEmail()                                                                           
        {                                                                                                                   
            throw new NotImplementedException();                                                                            
        }                                                                                                                   
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
                                                                                                                            
        // Delete LogIn ====================================================================================================
        public async Task<IActionResult> DeleteLogIn(string email)
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
