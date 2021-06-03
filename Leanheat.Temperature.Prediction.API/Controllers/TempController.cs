
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
            //HttpCookie MyCookie = Request.Cookies;

            //String[] arr1 = cookies.AllKeys;
            //// Request
            //var requestCookies = HttpContext.Request.Cookies; // Get cookies from the request

            //CookieContainer cookies = new CookieContainer(); // Cookie JAR
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.CookieContainer = cookies;

            //HttpClient client = new HttpClient(handler);
            ////HttpResponseMessage response = await client.DefaultRequestHeaders.GetValues();  // The Response





            //var cookies1 = HttpContext.Request.Cookies;

            //var myCookie = Request.Cookies;



            return Ok(_tempServices.GetTemps());
        }


        // Get - Temp ============================================================================== 
        [HttpGet("{id}", Name = "GetTemp")]
        public IActionResult GetTemp(string id)
        {
            return Ok(_tempServices.GetTemp(id));
        }



        // ADD - Temp ============================================================================== 
        [HttpPost]
        public IActionResult AddTemp(Temp temp)
        {
            _tempServices.AddTemp(temp);
            return CreatedAtRoute("GetTemp", new { id = temp.Id }, temp);
        }



        // Delete - Temp =========================================================================== 
        [HttpDelete("{id}")]
        public IActionResult DeleteTemp(string id)
        {
            _tempServices.DeleteTemp(id);
            return NoContent();
        }
    }
}
