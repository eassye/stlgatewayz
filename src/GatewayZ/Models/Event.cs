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
        [Required(ErrorMessage = "Please Provide a Title")]
        public string Title { get; set; }

        [Display(Name = "Start Date:")]
        [Required(ErrorMessage = "Please Provide a Start Date (MM/dd/yyyy)")]
        public string StartDate { get; set; }

        [Display(Name = "End Date:")]
        [Required(ErrorMessage = "Please Provide a End Date")]
        public string EndDate { get; set; }


        [Display(Name = "All Day:")]
        public bool AllDay { get; set; }

        //public string Location { get; set; }

        //public string Description { get; set; }

        //public string EventCreator { get; set; }
    }
}
