using Leanheat.Temperature.Search.API.Application.Interfaces;
using Leanheat.Temperature.Search.API.Domain.Models;
using Leanheat.Temperature.Search.API.MongoDB.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.API.Application.Services
{
    public class SearchServices : ISearchServices
    {
       
        private readonly IMongoCollection<SearchTemp> _searches;

        public SearchServices(IDbClient dbClient)
        {
            _searches = dbClient.GetSearchCollection();
        }

        public List<SearchTemp> GetSearchTemps() => _searches.Find(search => true).ToList();


        public List<SearchTemp> GetTemperatures() => _searches.Find(search => true).ToList();
    }
}
