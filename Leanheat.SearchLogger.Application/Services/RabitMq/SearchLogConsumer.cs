using Leanheat.SearchLogger.Application.Interfaces;
using Leanheat.SearchLogger.Domain.Models;
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



        // || Constructor || =============================================================================================
        public SearchLogConsumer(ISearchLoggerService searchLoggerService)
        {
            _searchLoggerService = searchLoggerService;
        }




        // Consume - Search - Parameter ===================================================================================
        public async Task Consume(ConsumeContext<SearchLog> context)
        {
            //var data = context.Message;
            var msg = context.Message;
            await _searchLoggerService.AddLog(msg);  // Save to DB
        }

    }
}
