using Leanheat.Temperature.Prediction.API.Domain.Models;
using Leanheat.Temperature.Prediction.API.Application.Interfaces.Infrastructure;
using Leanheat.Temperature.Prediction.API.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Prediction.API.MongoDB
{
    public class DbClient : IDbClient
    {

        private readonly IMongoCollection<Temp> _temps;

        //Construkter
        public DbClient(IOptions<TempDbConfig> tempDbConfig)
        {
            var client = new MongoClient(tempDbConfig.Value.Connection_String);
            var database = client.GetDatabase(tempDbConfig.Value.Database_Name);
            _temps = database.GetCollection<Temp>(tempDbConfig.Value.Temp_Collection_Name);
        }

        public IMongoCollection<Temp> GetTempCollection() => _temps;
       
    }
}
