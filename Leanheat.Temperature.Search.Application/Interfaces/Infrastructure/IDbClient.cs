using Leanheat.Temperature.Search.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.Application.Interfaces.Infrastructure
{
    public interface IDbClient
    {
        IMongoCollection<SearchModel> GetSearchCollection();
    }
}
