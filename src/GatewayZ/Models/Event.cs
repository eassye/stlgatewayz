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

        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Display(Name = "Start:")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End:")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Location:")]
        public string Location { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Created By:")]
        public string EventCreator { get; set; }
    }
}
