using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Api.Core
{
    public class TempDbConfig
    {

        public string Database_Name { get; set; }
        public string Temp_Collection_Name { get; set; }
        public string Connection_String { get; set; }

    }
}
