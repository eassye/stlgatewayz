using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;

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

        [Display(Name = "Display Name:")]
        [Required(ErrorMessage = "Please Provide a Display Name...")]
        public string displayName { get; set; }
        public string club { get; set; }
        public bool isMember { get; set; }
        public string clubRole {get; set;}
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

        //public User(User user)
        //{
        //    //Id = user.Id;
        //    firstName = user.firstName;
        //    lastName = user.lastName;
        //    email = user.email;
        //    displayName = user.displayName;
        //    password = user.password;
        //    securityQuestionOne = user.securityQuestionOne;
        //    securityQuestionTwo = user.securityQuestionTwo;
        //    answerOne = user.answerOne;
        //    answerTwo = user.answerTwo;
        //}

        //public User()
        //{

        //}
    }
}
