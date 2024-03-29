﻿using Leanheat.Temperature.Search.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.Application.Interfaces
{
    public interface ISearchServices
    {
        Task<List<SearchModel>> GetSearchResult(string searchParam);
        Task<List<SearchModel>> GetAll();
    }
}
