using Leanheat.Spa.Server.Application.Interfaces.Identity;
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

namespace Leanheat.Spa.Server.Application.Services.Identity
{
    public class IdentityAccountService : IIdentityAccountService
    {
        //private static readonly HttpClient client = new HttpClient();
        private readonly IHttpContextAccessor _httpContextAccessor; // Used for ex. Getting cookies --> Injected in Startup.cs --> By default works in Controllers without injection


        // Constructior
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
        public async Task<HttpResponseMessage> LogIn(string email, string password, bool rememberMe)                                    
        {

            CookieContainer cookies = new CookieContainer(); // Cookie JAR
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            HttpClient client = new HttpClient(handler);
            HttpResponseMessage response = client.PostAsync($"https://localhost:44347/Account/LogIn?email={email}&password={password}&rememberMe={rememberMe}", null).Result;
            

            Uri uri = new Uri("https://localhost:44347");
            IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
            foreach (Cookie cookie in responseCookies)
            {
                  // Create Cookie
                _httpContextAccessor.HttpContext.Response.Cookies.Append(cookie.Name, cookie.Value, new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddYears(500), HttpOnly = true, Secure = true, SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax });
            }

            return response;
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
