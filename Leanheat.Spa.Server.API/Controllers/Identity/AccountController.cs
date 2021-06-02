using Leanheat.Spa.Server.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // Services
        private readonly IIdentityAccountService _IdentityAccountService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IIdentityAccountService IdentityAccountService, IHttpContextAccessor HttpContextAccessor)
        {
            _IdentityAccountService = IdentityAccountService;
            _httpContextAccessor = HttpContextAccessor;
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {

            //// GET COOKIE
            ////read cookie from IHttpContextAccessor  
            //string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["key"];

            ////read cookie from Request object  
            //string cookieValueFromReq = Request.Cookies["Key"];


            // Cookie Container
            //CookieContainer cookies = new CookieContainer();
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.CookieContainer = cookies;

            //var result = await _IdentityAccountService.LogIn(email, password, rememberMe);


            //Uri uri = new Uri("https://localhost:44358");
            //IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
            //foreach (Cookie cookie in responseCookies)



                                                      

            var result = await _IdentityAccountService.LogIn(email, password, rememberMe);
            HttpContext.Response.Cookies.Append("cookie-name", "cookie-value", new CookieOptions { IsEssential = true });
            return  StatusCode(200, result);
        }
    }
}
