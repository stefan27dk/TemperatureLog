﻿using Leanheat.Temperature.Prediction.API.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Prediction.API.Application.Interfaces.Infrastructure
{
    public interface IDbClient
    {
        IMongoCollection<Temp> GetTempCollection();
    }
}
