using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.API.MongoDB.Models
{
    public class SearchDbConfig
    {
        public string Database_Name { get; set; }
        public string Temp_Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
