using Leanheat.Spa.Server.Application.Interfaces.TemperaturePrediction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.API.Controllers.TemperaturePrediction
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {

        // Services
        private readonly ITemperaturePredictionService _temperaturePredictionService;



        // || Constructor || ======================================================================
        public TempController(ITemperaturePredictionService temperaturePredictionService)
        {
            _temperaturePredictionService = temperaturePredictionService;
        }



        [HttpGet]
        [Route("GetAllTemp")]
        public async Task<IActionResult> GetAllTemp()
        {
            var response = await _temperaturePredictionService.GetAllTemp();
            return  StatusCode(200, response);
        }
    }
}
