
using Leanheat.Temperature.Prediction.API.Application.Interfaces;
using Leanheat.Temperature.Prediction.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Prediction.API.Controllers
{
    // Class ============= || Temp - Controller ||=================================================
    [Route("[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        // Services
        private readonly ITempServices _tempServices;
       


        // || Constructor || ======================================================================
        public TempController(ITempServices tempServices)
        {
            _tempServices = tempServices;
        }



        // GetALL - Temp ========================================================================== 
        [HttpGet]
        [Route("GetAllTemp")]
        public async Task<IActionResult> GetAllTemp()
        {
           // COOKIES------------->
            //// Request
            //var requestCookies = HttpContext.Request.Cookies; // Get cookies from the request

            //CookieContainer cookies = new CookieContainer(); // Cookie JAR
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.CookieContainer = cookies;

            //HttpClient client = new HttpClient(handler);
            //var response = client.DefaultRequestHeaders;  // The Response

          //var cookies1 = HttpContext.Request.Cookies;

          //var myCookie = Request.Cookies;

            return Ok(await _tempServices.GetAllTempsAsync());
        }


        // Get - Temp ============================================================================== 
        //[Route("GetTemp")]
        [HttpGet("GetTemp/{id}")]
        public async Task<IActionResult> GetTemp(string id)
        {
            return Ok(await _tempServices.GetTempByIdAsync(id));
        }



        // ADD - Temp ============================================================================== 
        [Route("AddTemp")]
        [HttpPost]
        public async Task<IActionResult> AddTemp(Temp temp)
        {
            await _tempServices.AddTempAsync(temp);
            return Ok();
        }



        // Delete - Temp =========================================================================== 
        [HttpDelete("DeleteTemp/{id}")]
        public async Task<IActionResult> DeleteTemp(string id)
        {
            await _tempServices.DeleteTempAsync(id);
            return NoContent();
        }
    }
}
