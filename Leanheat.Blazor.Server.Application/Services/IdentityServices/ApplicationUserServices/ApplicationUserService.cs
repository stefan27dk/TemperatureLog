using Leanheat.Blazor.Server.Application.Interfaces;
using Leanheat.Blazor.Shared.ViewModels;
using Leanheat.Blazor.Shared.ViewModels.AppUserViewModels;
using Leanheat.Identity.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
 

namespace Leanheat.Blazor.Server.Application.Services.IdentityServices.ApplicationUserServices
{

    // Class ============= || ApplicationUser - Service ||===============================================
    public class ApplicationUserService : IApplicationUserService
    {

        // Http CLient
        private readonly HttpClient httpClient;

        // Client Factory
        private readonly IHttpClientFactory clientFactory;

     


        // || Constructor || ============================================================================
        public ApplicationUserService(HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            this.httpClient = httpClient;
            this.clientFactory = clientFactory;
        }







          // Register ========================================================================================
        public async Task<IActionResult> Register(AppUserRegisterViewModel user)
        {
            var identityClient = clientFactory.CreateClient("IdentityAPI");
            return await identityClient.PostJsonAsync<IActionResult>($"/Account/Register?email={user.Email}&password={user.Password}&rememberMe={user.RememberMe}","");
            //https://localhost:44347/Account/Register?email=ui%40ui.dk&password=123456&rememberMe=true
        }
      






        // LogIn =========================================================================================
        public Task<IActionResult> LogIn(AppUserLogInViewModel user)
        {
            throw new NotImplementedException();
        }







        // GetCurrentUser ================================================================================
        public Task<AppUserGetViewModel> GetCurrentUser(AppUserGetViewModel user)
        {
            throw new NotImplementedException();
           //https://localhost:44347/Account/GetUser
        }


        




        // LogOut =========================================================================================
        public Task<IActionResult> LogOut()
        {
            throw new NotImplementedException();
        }







        // UpdateUser =======================================================================================
        public Task<IActionResult> UpdateUser(AppUserUpdateViewModel user)
        {
            throw new NotImplementedException();
        }  
        
        
        


        
        // DeleteLogIn ==================================================================================
        public Task<IActionResult> DeleteLogIn(string email)
        {
            throw new NotImplementedException();
        }


    }
}
