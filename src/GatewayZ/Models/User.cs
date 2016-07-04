using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


namespace GatewayZ.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Please Provide your First Name...")]
        public string firstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Please Provide your Last Name...")]
        public string lastName { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email Address is Required...")]
        [EmailAddress(ErrorMessage = "Invalid Email Address...")]
        public string email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required...")]
        public string phoneNumber { get; set; }

        [Display(Name = "Display Name:")]
        [Required(ErrorMessage = "Please Provide a Display Name...")]
        public string displayName { get; set; }

        [Display(Name = "Club:")]
        public string club { get; set; }

        [Display(Name = "Member Status:")]
        public bool isMember { get; set; }

        [Display(Name = "Club Roles:")]
        public string clubRole {get; set;}

        [Display(Name = "User Type:")]
        public string userType { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Please Provide a Password...")]
        public string password { get; set; }

        [Display(Name = "Security Question 1:")]
        [Required(ErrorMessage = "Please Select a Security Question...")]
        public List<string> securityQuestionOne { get; set; }

        [Display(Name = "Security Question 2:")]
        [Required(ErrorMessage = "Please Select a Security Question...")]
        public List<string> securityQuestionTwo { get; set; }

        [Display(Name = "Security Answer 1:")]
        [Required(ErrorMessage = "Please Enter a Security Question Answer...")]
        public string answerOne { get; set; }

        [Display(Name = "Security Answer 2:")]
        [Required(ErrorMessage = "Please Enter a Security Question Answer...")]
        public string answerTwo { get; set; }
    }
}
