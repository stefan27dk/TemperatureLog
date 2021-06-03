using Leanheat.Spa.Server.Domain.Models.TemperaturePredictionModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.Application.Interfaces.TemperaturePrediction
{
    public interface ITemperaturePredictionService
    {
        // === Get All - Temp ======================================================================
        public Task<IActionResult> GetAllTemp();
    }
}
