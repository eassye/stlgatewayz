using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GatewayZ.Models;

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
            return RedirectToAction("Index");
        }
    }
}
