using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.Domain.Models.TemperaturePredictionModels
{
    public class Temp
    {
        public string Id { get; set; }
        public double Predicted_temp { get; set; }
        public string Datetime { get; set; }
    }
}
