using Leanheat.SearchLogger.Application.Interfaces;
using Leanheat.SearchLogger.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leanheat.SearchLogger.API.Controllers
{

    // Class ============= || Controller ||========================================================
    [Route("api/[controller]")]
    [ApiController]
    public class SearchLogger : ControllerBase
    {

        private readonly ISearchLoggerService _searchLoggerService;
        // || Constructor || ======================================================================
        public SearchLogger(ISearchLoggerService searchLoggerService)
        {
            _searchLoggerService = searchLoggerService;
        }





        // || Logger Search - POST || ======================================================================
        [HttpPost]
        [Route("AddLog")]
        public async Task<IActionResult> AddLog(SearchLog searchString)
        {
            await _searchLoggerService.AddLog(searchString);
            return CreatedAtRoute("AddLog", new { id = searchString.Id }, searchString);

        }






        // || Logger Search - GET || ======================================================================
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _searchLoggerService.GetAll());
        }



    }
}
