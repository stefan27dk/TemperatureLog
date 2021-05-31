using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Temperature.Search.Domain.Models
{
    [Serializable]
    public class SearchModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public double Predicted_temp { get; set; }
        public string Datetime { get; set; }
    }
}
