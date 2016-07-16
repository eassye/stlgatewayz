using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace GatewayZ.Models
{
    public class Event
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [Display(Name = "Title:")]
        public string title { get; set; }

        [Display(Name = "Start:")]
        public DateTime startDate { get; set; }

        [Display(Name = "End:")]
        public DateTime endDate { get; set; }

        [Display(Name = "Location:")]
        public string location { get; set; }

        [Display(Name = "Description:")]
        public string description { get; set; }

        [Display(Name = "Created By:")]
        public string eventCreator { get; set; }
    }
}
