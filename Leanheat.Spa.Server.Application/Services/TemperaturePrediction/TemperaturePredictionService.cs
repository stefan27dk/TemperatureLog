using Leanheat.Spa.Server.Application.Interfaces.TemperaturePrediction;
using Leanheat.Spa.Server.Domain.Models.TemperaturePredictionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.Application.Services.TemperaturePrediction
{
    public class TemperaturePredictionService : ITemperaturePredictionService
    {
        // Services
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _predictTemperatureApiAddress = ServicesAddresses.PredictTemperatureApiAddress; // PredictTemperatureApiAddress Api Address


        // || Constructor || ======================================================================
        public TemperaturePredictionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        // === Get All - Temp ======================================================================
        public async Task<IActionResult> GetAllTemp()
        {



            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_predictTemperatureApiAddress + $"/Temp/GetAllTemp");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return new JsonResult(await reader.ReadToEndAsync());
            }



            //// Request
            //var requestCookies = _httpContextAccessor.HttpContext.Request.Cookies; // Get cookies from the request

            //CookieContainer cookies = new CookieContainer(); // Cookie JAR
            //HttpClientHandler handler = new HttpClientHandler();
            //handler.CookieContainer = cookies;

            //HttpClient client = new HttpClient(handler);
            //HttpResponseMessage response = await client.GetAsync(_predictTemperatureApiAddress + "/Temp/GetAllTemp");  // The Response

            //// Create Cookies  
            //foreach (var cookie in requestCookies)
            //{
            //    // Create Cookie
            //    _httpContextAccessor.HttpContext.Response.Cookies.Append(cookie.Key, cookie.Value);
            //}



            //return new JsonResult(_httpContextAccessor.HttpContext.Response);
        }
             
    }
}
