using Leanheat.Temperature.Search.API.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.API.MongoDB.Interfaces
{
    public interface IDbClient
    {
        IMongoCollection<SearchTemp> GetSearchCollection();
    }
}
