using Leanheat.Temperature.Prediction.API.Application.Interfaces;
using Leanheat.Temperature.Prediction.API.Domain.Models;
using Leanheat.Temperature.Prediction.API.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Leanheat.Temperature.Prediction.API.Application.Services
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

        public void DeleteTemp(string id)
        {
            _temps.DeleteOne(temp => temp.Id == id);
        }

        public Temp GetTemp(string id) => _temps.Find(temp => temp.Id == id).First();
       

        public List<Temp> GetTemps() => _temps.Find(temp => true).ToList();
        
            
    }
}
