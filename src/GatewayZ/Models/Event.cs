using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GatewayZ.Models
{
    public class Event
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        //public int EventID { get; set;}

        public string Title { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool AllDay { get; set; }

        //public string Location { get; set; }

        //public string Description { get; set; }

        //public string EventCreator { get; set; }
    }
}
