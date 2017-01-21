using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GatewayZ.Models;
using GatewayZ.Services;

namespace GatewayZ.Controllers.Web
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View("SignUp");
        }

        [HttpPost]
        public IActionResult Index(SignUp signUp)
        {
            try
            {
                var email = new SignUpService(signUp);
                email.SendCreateAccountReminderEmail();
                email.SendRegistrationEmail();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
