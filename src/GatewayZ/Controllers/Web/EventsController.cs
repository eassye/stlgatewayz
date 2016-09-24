using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GatewayZ.GatewayZDAO;
using GatewayZ.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GatewayZ.Controllers.Web
{
    public class EventsController : Controller
    {
        private UserDAO _userDAO;
        private EventDAO _eventDAO;

        public EventsController()
        {
            _userDAO = new UserDAO();
            _eventDAO = new EventDAO();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            string authUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (authUser == "Admin" || authUser == "RegisteredUser")
            {
                return View("Events");
            }
            else
            {
                return RedirectToAction("Index", "UnauthorizedUser", new { area = "" });
            }
        }

        public IActionResult GetEvents()
        {
            var listEvents = _eventDAO.GetEvents();

            var eventList = from e in listEvents
                            select new
                            {
                                title = e.Title,
                                start = e.StartDate.ToString(),
                                end = e.EndDate.ToString(),
                            };

            return Json(eventList);
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        [HttpPost]
        public IActionResult SaveEvent([Bind]Event events)
        {
            if (ModelState.IsValid)
            {
                events.StartDate.ToString();
                _eventDAO.SaveEvent(events);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "App", new { area = "" });
        }
    }
}
