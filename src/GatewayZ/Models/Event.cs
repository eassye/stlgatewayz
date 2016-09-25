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

        [DataType(DataType.Date)]
        [Display(Name = "Start Date:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Please Provide a Start Date (MM/dd/yyyy)")]
        public DateTime StartDate { get; set; }

        //[DataType(DataType.Time)]
        //[Display(Name = "Start Time:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh:mm}")]
        //[Required(ErrorMessage = "Please Provide a Start Time (HH:mm")]
        //public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Please Provide a End Date")]
        public string EndDate { get; set; }

        //[DataType(DataType.Time)]
        //[Display(Name = "End Time:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh:mm}")]
        //[Required(ErrorMessage = "Please Provide a End Time (HH:mm")]
        //public DateTime EndTime { get; set; }

        [Display(Name = "All Day:")]
        public bool AllDay { get; set; }

        //public string Location { get; set; }

        //public string Description { get; set; }

        //public string EventCreator { get; set; }
    }
}
