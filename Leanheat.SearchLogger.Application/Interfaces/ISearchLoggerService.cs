using Leanheat.SearchLogger.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.SearchLogger.Application.Interfaces
{
    public interface ISearchLoggerService
    {
        Task<SearchLog> AddLog(SearchLog searchString);
       
        Task<List<SearchLog>> GetAll();
    }
}
