using Leanheat.Temperature.Search.Application.Interfaces;
using Leanheat.Temperature.Search.Application.Interfaces.Infrastructure;
using Leanheat.Temperature.Search.Domain.Models;
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


        public List<SearchModel> GetSearchResult() => _searchs.Find(searches => true).ToList();
      
    }
}
