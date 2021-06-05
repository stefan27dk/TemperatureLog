using Leanheat.Common.Models;
using Leanheat.SearchLogger.Application.Interfaces;   
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.SearchLogger.Application.Services.RabitMq
{
    public class SearchLogConsumer : IConsumer<SearchLog>
    {

        // Services
        private readonly ISearchLoggerService _searchLoggerService;

        // Props
        //SearchLog log = new SearchLog();

        // || Constructor || =============================================================================================
        public SearchLogConsumer(ISearchLoggerService searchLoggerService)
        {
            _searchLoggerService = searchLoggerService;
        }




        // Consume - Search - Parameter ===================================================================================
        public async Task Consume(ConsumeContext<SearchLog> context)
        {  
            //log.Search = context.Message.Search;
            await _searchLoggerService.AddLog(context.Message);  // Save to DB
        }

    }
}
