using Leanheat.Temperature.Search.Application.Interfaces;
using Leanheat.Temperature.Search.Application.Interfaces.Infrastructure;
using Leanheat.Temperature.Search.Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.Application.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly IMongoCollection<SearchModel> _searchs;
        

        // Constructor
        public SearchServices(IDbClient dbClient)
        {
            _searchs = dbClient.GetSearchCollection();  
        }



      

    
        //public List<SearchModel> GetSearchResult(string searchParam) => _searchs.Find(x => x.Datetime == searchParam).ToList();
        public List<SearchModel> GetSearchResult(string searchParam) => _searchs.Find(new BsonDocument { { "Datetime", new BsonDocument { { "$regex", searchParam }, { "$options", "i" } } } }).ToList(); // Search DateTime "*like"

        public List<SearchModel> GetAll() => _searchs.Find(x => true).ToList();
 
    }
}
