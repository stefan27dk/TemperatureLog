using Leanheat.Temperature.Search.Application.Interfaces.Infrastructure;
using Leanheat.Temperature.Search.Domain.Models;
using Leanheat.Temperature.Search.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.MongoDB
{
    public class DbClient : IDbClient
    {

        private readonly IMongoCollection<SearchModel> _searchs;

        
        
        // Constructor
        public DbClient(IOptions<SearchDbConfig> searchDbConfig)
        {
            var client = new MongoClient(searchDbConfig.Value.Connection_String);
            var database = client.GetDatabase(searchDbConfig.Value.Database_Name);
            _searchs = database.GetCollection<SearchModel>(searchDbConfig.Value.Search_Collection_Name);
        }


        public IMongoCollection<SearchModel> GetSearchCollection() => _searchs;
     
    }
}
