using Leanheat.SearchLogger.Application.Interfaces.Infrastructure;
using Leanheat.SearchLogger.Domain.Models;
using Leanheat.SearchLogger.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.SearchLogger.MongoDB
{
    public class DbClient : IDbClient
    {

        private readonly IMongoCollection<SearchLog> _searchlog;

        //Construkter
        public DbClient(IOptions<SearchLogDbConfig> tempDbConfig)
        {
            var client = new MongoClient(tempDbConfig.Value.Connection_String);
            var database = client.GetDatabase(tempDbConfig.Value.Database_Name);
            _searchlog = database.GetCollection<SearchLog>(tempDbConfig.Value.Search_Collection_Name);
        }

        public IMongoCollection<SearchLog> GetSearchLogCollection() => _searchlog;

    }
}
