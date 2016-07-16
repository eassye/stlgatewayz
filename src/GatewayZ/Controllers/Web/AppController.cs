using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using GatewayZ.Services;
using GatewayZ.Models;
using MongoDB.Bson;
using System.Security.Claims;
using Microsoft.AspNet.Http;
using GatewayZ.GatewayZDAO;

namespace GatewayZ.Controllers.Web
{
    public class AppController : Controller
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public AppController()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(("GatewayZ"));
        }

        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            return PartialView();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            try
            {
                var collection = _database.GetCollection<User>("User");
                var filter = Builders<User>.Filter.Eq("email", user.email);
                var document = collection.Find(filter).First();

                if (document.email == user.email && document.password == user.password)
                {
                    HttpContext.Session.SetString("Email", document.email);
                    HttpContext.Session.SetString("Password", document.password);
                    return RedirectToAction("Index");
                }
                else
                {
                    return PartialView();
                }
            }
            catch
            {
                return PartialView();
            }
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View();
        }

        public IActionResult Events()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View();
        }

        public IActionResult BecomeAMember()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            var collection = _database.GetCollection<User>("User");

            collection.InsertOneAsync(user);

            return RedirectToAction("Index");
        }

        public IActionResult Gallery()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View();
        }

        public IActionResult Members()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            return View();
        }

        public IActionResult History()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            var _service = new HistoryServices();

            return View(_service);
        }

        public IActionResult Admin()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            UserDAO _userDAO = new UserDAO();

            string authUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (authUser == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Admin(AdminPageModel _data)
        {
            if(_data.User != null)
            {
                UserDAO userUpdate = new UserDAO();

                userUpdate.SaveUser(_data.User);
            }
            
            if(_data.Club != null)
            {
                ClubDAO clubUpdate = new ClubDAO();

                clubUpdate.SaveClub(_data.Club);
            }
            
            return RedirectToAction("Admin");
        }
    }
}
