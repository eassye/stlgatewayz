using System;
using Microsoft.AspNetCore.Mvc;
using GatewayZ.Models;
using GatewayZ.Services;
using Microsoft.AspNetCore.Http;
using GatewayZ.GatewayZDAO;

namespace GatewayZ.Controllers.Web
{
    public class SignUpController : Controller
    {
        private UserDAO _userDAO;

        public SignUpController()
        {
            _userDAO = new UserDAO();
        }

        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

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
