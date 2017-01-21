using GatewayZ.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Text;

namespace GatewayZ.Services
{
    public class SignUpService
    {
        private readonly SignUp _signUp;

        public SignUpService(SignUp signUp)
        {
            _signUp = signUp;
        }

        public void SendRegistrationEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Erick", "eassye1@yahoo.com"));
            message.To.Add(new MailboxAddress("Cathy", "Gatewayzclub@yahoo.com"));
            message.Subject = "STLGatewayZ Signup Form From: " + _signUp.Personal.Name;
            message.Body = new TextPart("plain")
            {
                Text = CreateEmail()
            };
            
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.yahoo.com", 587, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     client.Authenticate("anuraj.p@example.com", "password");
                client.Authenticate("eassye1@yahoo.com", "370ZNismo");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendCreateAccountReminderEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Erick", "eassye1@yahoo.com"));
            message.To.Add(new MailboxAddress(_signUp.Personal.Name, _signUp.Personal.Email));
            message.Subject = "STLGatewayZ Signup Form From: " + _signUp.Personal.Name;
            message.Body = new TextPart("plain")
            {
                Text = CreateAccountReminderEmail()
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mail.yahoo.com", 587, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     client.Authenticate("anuraj.p@example.com", "password");
                client.Authenticate("eassye1@yahoo.com", "370ZNismo");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private string CreateAccountReminderEmail()
        {
            var email = new StringBuilder();
            email.Append(_signUp.Personal.Name + " ,");
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("Thank you for applying to join STL Gateway Z Club!");
            email.Append(Environment.NewLine);
            email.Append("Your application has been sent for review.");
            email.Append(Environment.NewLine);
            email.Append("If you have not already created an account, please do so at: http://www.gatewayzclub.com/Register");
            return email.ToString();
        }

        private string CreateEmail()
        {
            var email = new StringBuilder();
            email.Append("Cathy Scott, ");
            email.Append(Environment.NewLine);
            email.Append(_signUp.Personal.Name + " Is Requesting Acceptance into STLGateway Z");
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("Gateway Z Club Signup Sheet Information:");
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("ENROLLMENT:");
            email.Append(Environment.NewLine);
            email.Append("Renewal: " + _signUp.Enrollment.Renewal);
            email.Append(Environment.NewLine);
            email.Append("New Membership: " + _signUp.Enrollment.NewMembership);
            email.Append(Environment.NewLine);
            email.Append("Referred By: " + _signUp.Enrollment.ReferredBy);
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("PERSONAL INFORMATION:");
            email.Append(Environment.NewLine);
            email.Append("Name: ");
            email.Append(Environment.NewLine);
            email.Append("Birthday: " + _signUp.Personal.BirthDay);
            email.Append(Environment.NewLine);
            email.Append("Significant Other's Name: " + _signUp.Personal.SignificantOthersName);
            email.Append(Environment.NewLine);
            email.Append("Anniversary: " + _signUp.Personal.Anniversary);
            email.Append(Environment.NewLine);
            email.Append("Street Address: " + _signUp.Personal.StreetAddress);
            email.Append(Environment.NewLine);
            email.Append("City: " + _signUp.Personal.City);
            email.Append(Environment.NewLine);
            email.Append("State: " + _signUp.Personal.State);
            email.Append(Environment.NewLine);
            email.Append("ZIP: " + _signUp.Personal.ZipCode);
            email.Append(Environment.NewLine);
            email.Append("Primary Phone Number:" + _signUp.Personal.PrimaryPhone);
            email.Append(Environment.NewLine);
            email.Append("Email: " + _signUp.Personal.Email);
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("VEHICALS OWNED:");
            email.Append(Environment.NewLine);
            email.Append("Make: " + _signUp.Vehicals.Make);
            email.Append(Environment.NewLine);
            email.Append("Model: " + _signUp.Vehicals.Model);
            email.Append(Environment.NewLine);
            email.Append("Body Style: " + _signUp.Vehicals.BodyStyle);
            email.Append(Environment.NewLine);
            email.Append("Year: " + _signUp.Vehicals.Year);
            email.Append(Environment.NewLine);
            email.Append("Color: " + _signUp.Vehicals.Color);
            email.Append(Environment.NewLine);
            email.Append("Modified: " + _signUp.Vehicals.Modified);
            email.Append(Environment.NewLine);
            email.Append("Make: " + _signUp.Vehicals.MakeTwo);
            email.Append(Environment.NewLine);
            email.Append("Model: " + _signUp.Vehicals.ModelTwo);
            email.Append(Environment.NewLine);
            email.Append("Body Style: " + _signUp.Vehicals.BodyStyleTwo);
            email.Append(Environment.NewLine);
            email.Append("Year: " + _signUp.Vehicals.YearTwo);
            email.Append(Environment.NewLine);
            email.Append("Color: " + _signUp.Vehicals.ColorTwo);
            email.Append(Environment.NewLine);
            email.Append("Modified: " + _signUp.Vehicals.ModifiedTwo);
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("Z INTERESTS");
            email.Append(Environment.NewLine);
            email.Append("ZInterest: " + _signUp.ZInterests.ZInterestTitle);
            email.Append(Environment.NewLine);
            email.Append("Autocross: " + _signUp.ZInterests.Autocross);
            email.Append(Environment.NewLine);
            email.Append("Restoration: " + _signUp.ZInterests.Restoration);
            email.Append(Environment.NewLine);
            email.Append("SocialEvent: " + _signUp.ZInterests.SocialEvent);
            email.Append(Environment.NewLine);
            email.Append("Rallies: " + _signUp.ZInterests.Rallies);
            email.Append(Environment.NewLine);
            email.Append("DragRacing: " + _signUp.ZInterests.DragRacing);
            email.Append(Environment.NewLine);
            email.Append("CarShows: " + _signUp.ZInterests.CarShows);
            email.Append(Environment.NewLine);
            email.Append("SportsCarRacing: " + _signUp.ZInterests.SportsCarRacing);
            email.Append(Environment.NewLine);
            email.Append("Customizing: " + _signUp.ZInterests.Customizing);
            email.Append(Environment.NewLine);
            email.Append("SCCARegion: " + _signUp.ZInterests.SCCARegion);
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("SIGNATURE");
            email.Append(Environment.NewLine);
            email.Append("Name: " + _signUp.Signature.Name);
            email.Append(Environment.NewLine);
            email.Append("Date: " + _signUp.Signature.Date);
            email.Append(Environment.NewLine);
            email.Append(Environment.NewLine);
            email.Append("WAIVER");
            email.Append(Environment.NewLine);
            email.Append("DateReceived: " + _signUp.Waiver.DateReceived);
            email.Append(Environment.NewLine);
            email.Append("PaymentMethod: " + _signUp.Waiver.PaymentMethod);
            email.Append(Environment.NewLine);
            email.Append("CheckNumber: " + _signUp.Waiver.CheckNumber);
            email.Append(Environment.NewLine);
            email.Append("AmountRecieved: " + _signUp.Waiver.AmountRecieved);
            email.Append(Environment.NewLine);
            email.Append("DateEntered: " + _signUp.Waiver.DateEntered);
            email.Append(Environment.NewLine);
            email.Append("PackageSent: " + _signUp.Waiver.PackageSent);
            email.Append(Environment.NewLine);
            email.Append("MembershipNumber: " + _signUp.Waiver.MembershipNumber);

            return email.ToString();
        }
    }
}
