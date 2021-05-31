using Leanheat.Temperature.Search.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly ISearchServices _searchServices;

        public SearchController(ISearchServices searchServices)
        {
            _searchServices = searchServices;
        }

        [HttpGet]
        [Route("GetAllTemp")]
        public IActionResult GetAllTemp()
        {
            return Ok(_searchServices.GetSearchTemps());
        }

    }
}
