using Leanheat.Temperature.Prediction.API.Domain.Models;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Prediction.API.Application.Interfaces
{
    public interface ITempServices
    {
        // Get Tempeartures
        public Task<List<Temp>> GetAllTempsAsync();


        // Get Temperature
       public Task<Temp> GetTempByIdAsync(string id);
     
        
        // Add Temperature
        public Task AddTempAsync(Temp temp);


        // Delete Temperature
        public Task DeleteTempAsync(string id);
    }
}
