using Leanheat.Temperature.Api.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Prediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TempController : ControllerBase
    {
        private readonly ITempServices _tempServices;

        public TempController(ITempServices tempServices)
        {
            _tempServices = tempServices;
        }

        [HttpGet]
        public IActionResult GetAllTemp()
        {
            return Ok(_tempServices.GetTemps());
        }

        [HttpGet("{id}", Name = "GetTemp")]
        public IActionResult GetTemp(string id)
        {
            return Ok(_tempServices.GetTemp(id));
        }

        [HttpPost]
        public IActionResult AddTemp(Temp temp)
        {
            _tempServices.AddTemp(temp);
            return CreatedAtRoute("GetTemp", new { id = temp.Id }, temp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTemp(string id)
        {
            _tempServices.DeleteTemp(id);
            return NoContent();
        }
     

       
    }
}
