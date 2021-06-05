using Leanheat.Common.Models;  
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.SearchLogger.Application.Interfaces.Infrastructure
{
    public interface IDbClient
    {
        IMongoCollection<SearchLog> GetSearchLogCollection();
    }
}
