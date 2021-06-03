using Leanheat.Spa.Server.Application.Interfaces.Identity;
using Leanheat.Spa.Server.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Net.Http.Headers;

namespace Leanheat.Spa.Server.Application.Services.Identity
{
    // Class ============= || Identity - Account - Service ||=============================================================
    public class IdentityAccountService : IIdentityAccountService
    {
         
        private readonly IHttpContextAccessor _httpContextAccessor; // Used for ex. Getting cookies --> Injected in Startup.cs --> By default works in Controllers without injection
        private readonly string _identityApiAddress = ServicesAddresses.IdentityApiAddress; // Identity Api Address



        // || Constructor || ==============================================================================================
        public IdentityAccountService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

    
      

        // Register ======================================================================================================== 
        public async Task<IActionResult> Register(string firstname, string lastname, string email, string age, string phonenumber, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }





        // Log In ==========================================================================================================
        public async Task<IActionResult> LogIn(string email, string password, bool rememberMe)                                    
        {
            CookieContainer cookies = new CookieContainer(); // Cookie JAR
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            HttpClient client = new HttpClient(handler);
            HttpResponseMessage response = client.PostAsync($"{_identityApiAddress}/Account/LogIn?email={email}&password={password}&rememberMe={rememberMe}", null).Result;  // The Response
            

            //Uri uri = new Uri(_identityApiAddress);
            IEnumerable<Cookie> responseCookies = cookies.GetCookies(new Uri(_identityApiAddress)).Cast<Cookie>(); // Get the Cookies to list from the specified URI - Address
           

            // Create Cookies -------------------------------------------------------------------------------------------------------------------------------------------------------
            foreach (Cookie cookie in responseCookies)
            {
                if (cookie.Expires == DateTime.Parse("01 - 01 - 0001 00:00:00")) // If Session Cookie
                {
                   // Create Cookie
                   _httpContextAccessor.HttpContext.Response.Cookies.Append(cookie.Name, cookie.Value, new CookieOptions { IsEssential = true, HttpOnly = cookie.HttpOnly, Secure = cookie.Secure, SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax });
                }
                else  // Persitent Cookie
                {
                    // Create Cookie
                    _httpContextAccessor.HttpContext.Response.Cookies.Append(cookie.Name, cookie.Value, new CookieOptions { IsEssential = true, Expires = cookie.Expires, HttpOnly = cookie.HttpOnly, Secure = cookie.Secure, SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax });
                }
            }

           
            return new JsonResult(response.StatusCode);
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
