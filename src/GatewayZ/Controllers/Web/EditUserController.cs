using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Http;
using GatewayZ.Services;
using GatewayZ.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GatewayZ.Controllers.Web
{
    public class EditUserController : Controller
    {
        private UserDAO _userDAO;

        public EditUserController()
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

            return View("EditUser");
        }

        [HttpPost]
        public IActionResult Index(User _user)
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            var _service = new EditUserServices(_userDAO);

            _service.ProcessUpdate(_user, ViewBag.Email);

            return RedirectToAction("Index");
        }
    }
}
