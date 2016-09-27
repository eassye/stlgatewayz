using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using GatewayZ.Services;
using Microsoft.AspNetCore.Http;
using System;

namespace GatewayZ.Controllers.Web
{
    public class Gallery2002Controller : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private UserDAO _userDAO;

        public Gallery2002Controller()
        {
            _hostingEnvironment = new HostingEnvironment();
            _userDAO = new UserDAO();
        }

        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
                ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);
            }
            
            return View("Gallery2002");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "App", new { area = "" });
        }
    }
}
