using Leanheat.Blazor.Server.Application.Interfaces;
using Leanheat.Blazor.Shared.ViewModels;
using Leanheat.Blazor.Shared.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Blazor.Server.Controllers
{
    // Class ============= || AccountController ||===============================================
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        // ApplicationUserService
        private readonly IApplicationUserService applicationUserService;




        // || Constructor || ============================================================================
        public AccountController(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;  // ApplicationUserService
        }





        // Register =======================================================================================
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AppUserRegisterViewModel user)
        {
            return await applicationUserService.Register(user); // Register - ApplicationUserService
            //https://localhost:44347/Account/Register?email=ui%40ui.dk&password=123456&rememberMe=true
        }


    }
}
