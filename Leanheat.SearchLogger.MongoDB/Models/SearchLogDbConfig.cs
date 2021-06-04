using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.SearchLogger.MongoDB.Models
{
    public  class SearchLogDbConfig
    {
        public string Database_Name { get; set; }
        public string Search_Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
