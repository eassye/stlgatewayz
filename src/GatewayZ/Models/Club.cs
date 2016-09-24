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
        public string clubHistory { get; set; }
        public string president { get; set; }
        public string vicePresident { get; set; }
        public string treasurer { get; set; }
        public string secretary { get; set; }
        public string webMaster { get; set; }
        public string socialMediaDirector { get; set; }
        public string membershipDirector { get; set; }
    }
}
