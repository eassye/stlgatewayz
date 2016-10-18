using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GatewayZ.Controllers.Web
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View("SignUp");
        }
    }
}
