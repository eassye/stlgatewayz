using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace GatewayZ.Models
{
    public class Club
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string clubName { get; set; }
        public string clubCode { get; set; }
        public byte[] clubLogo { get; set; }
    }
}
