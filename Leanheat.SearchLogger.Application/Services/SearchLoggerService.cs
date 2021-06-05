using Leanheat.Common.Models;
using Leanheat.SearchLogger.Application.Interfaces;
using Leanheat.SearchLogger.Application.Interfaces.Infrastructure;
 
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.SearchLogger.Application.Services
{
    public class SearchLoggerService : ISearchLoggerService
    {

        // Collection
        private readonly IMongoCollection<SearchLog> _SearchLogs;


        // Cosntructor
        public SearchLoggerService(IDbClient dbClient)
        {
            _SearchLogs = dbClient.GetSearchLogCollection();
        }



        // AddLog
        public async Task<SearchLog> AddLog(SearchLog searchString)
        {
            await _SearchLogs.InsertOneAsync(searchString);
            return searchString;
        }




        // Get ALL
        public async Task<List<SearchLog>> GetAll()
        {
           return await _SearchLogs.Find(x => true).ToListAsync();
        }

    }
}
