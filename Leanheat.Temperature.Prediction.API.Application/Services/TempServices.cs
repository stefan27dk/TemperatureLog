using Leanheat.Temperature.Prediction.API.Application.Interfaces;
using Leanheat.Temperature.Prediction.API.Domain.Models;
using Leanheat.Temperature.Prediction.API.Application.Interfaces.Infrastructure;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Prediction.API.Application.Services
{
    public class TempServices : ITempServices
    {
        private readonly IMongoCollection<Temp> _temps;


        // Controller
        public TempServices(IDbClient dbClient)
        {
            _temps = dbClient.GetTempCollection();
        }


        // Add Temp
        public async Task AddTempAsync(Temp temp)
        {
           await _temps.InsertOneAsync(temp);  
        }


        // Delete Temp
        public async Task DeleteTempAsync(string id)
        {
           await _temps.DeleteOneAsync(temp => temp.Id == id);
        }



        // Get Temp
        public async Task<Temp> GetTempByIdAsync(string id)
        {
            //return Task.FromResult(_temps.Find(temp => temp.Id == id).First());
            return await _temps.FindAsync(temp => temp.Id == id).Result.FirstOrDefaultAsync();

        }



        // Get All Temps
        //public Task<List<Temp>> GetAllTemps() => _temps.Find(temp => true).ToList();

        public Task<List<Temp>> GetAllTempsAsync()
        {
           return  _temps.FindAsync(temp => true).Result.ToListAsync();
        }
      
    }
}
