using Leanheat.Temperature.Search.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.API.Application.Interfaces
{
    public interface ISearchServices
    {

        List<SearchTemp> GetSearchTemps();


    }
}
