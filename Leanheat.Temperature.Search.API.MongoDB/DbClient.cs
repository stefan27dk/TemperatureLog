using Leanheat.Temperature.Search.API.Domain.Models;
using Leanheat.Temperature.Search.API.MongoDB.Interfaces;
using Leanheat.Temperature.Search.API.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.API.MongoDB
{
    public class DbClient : IDbClient
    {

        private readonly IMongoCollection<SearchTemp> _seaches;

        public DbClient(IOptions<SearchDbConfig> searchDbConfig)
        {
            var client = new MongoClient(searchDbConfig.Value.Connection_String);
            var database = client.GetDatabase(searchDbConfig.Value.Database_Name);
            _seaches = database.GetCollection<SearchTemp>(searchDbConfig.Value.Temp_Collection_Name);
        }

        public IMongoCollection<SearchTemp> GetSearchCollection() => _seaches;
       
    }
}
