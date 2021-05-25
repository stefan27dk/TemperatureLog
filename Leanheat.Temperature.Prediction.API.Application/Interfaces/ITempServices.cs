using Leanheat.Temperature.Prediction.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Prediction.API.Application.Interfaces
{
    public interface ITempServices
    {
        List<Temp> GetTemps();

        Temp GetTemp(string id);
        Temp AddTemp(Temp temp);

        void DeleteTemp(string id);
    }
}
