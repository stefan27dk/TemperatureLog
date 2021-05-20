using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Leanheat.Temperature.Api.Core
{
    public class TempServices : ITempServices
    {
        private readonly IMongoCollection<Temp> _temps;

        public TempServices(IDbClient dbClient)
        {
            _temps = dbClient.GetTempCollection();
        }

        public Temp AddTemp(Temp temp)
        {
            _temps.InsertOne(temp);
            return temp;
        }

        public List<Temp> GetTemps() => _temps.Find(temp => true).ToList();
        
            
    }
}
