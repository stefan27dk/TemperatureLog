using Leanheat.Temperature.Search.Application.Interfaces;
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


        // Constructor
        public SearchController(ISearchServices searchServices)
        {
            _searchServices = searchServices;
        }


       
        [HttpGet]
        [Route("GetSearchResult")]
        public IActionResult GetSearchResult()
        {
            return Ok(_searchServices.GetSearchResult());
        }
       
    }
}
