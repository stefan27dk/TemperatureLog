using Leanheat.Spa.Server.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityAccountService _IdentityAccountService;

        public AccountController(IIdentityAccountService IdentityAccountService)
        {
            _IdentityAccountService = IdentityAccountService;
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var result = await _IdentityAccountService.LogIn(email, password, rememberMe);
          return  StatusCode(200, result);
        }
    }
}
