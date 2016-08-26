﻿using Microsoft.AspNet.Mvc;
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
            _client = new MongoClient("mongodb://gatewayz:370zNismo@ds044229.mlab.com:44229/gatewayz");
            _database = _client.GetDatabase(("gatewayz"));
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

        public IActionResult Events(Event events)
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            return View();
        }

        
        public IActionResult GetEvents()
        {
            EventDAO events = new EventDAO();

            var listEvents = events.GetEvents();

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
        public IActionResult SaveEvents(Event events)
        {
            EventDAO addEvent = new EventDAO();

            addEvent.SaveEvent(events);

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

            ViewBag.fileCount2002Folder = _service.CountFiles(@"Images\Gallery\2002");
            ViewBag.file2002ModifiedDate = _service.LastDateModified(@"Images\Gallery\2002");

            ViewBag.fileCount2003Folder = _service.CountFiles(@"Images\Gallery\2003");
            ViewBag.file2003ModifiedDate = _service.LastDateModified(@"Images\Gallery\2003");

            ViewBag.fileCount2004Folder = _service.CountFiles(@"Images\Gallery\2004");
            ViewBag.file2004ModifiedDate = _service.LastDateModified(@"Images\Gallery\2004");

            ViewBag.fileCount2005Folder = _service.CountFiles(@"Images\Gallery\2005");
            ViewBag.file2005ModifiedDate = _service.LastDateModified(@"Images\Gallery\2005");

            ViewBag.fileCount2006Folder = _service.CountFiles(@"Images\Gallery\2006");
            ViewBag.file2006ModifiedDate = _service.LastDateModified(@"Images\Gallery\2006");

            ViewBag.fileCount2007Folder = _service.CountFiles(@"Images\Gallery\2007");
            ViewBag.file2007ModifiedDate = _service.LastDateModified(@"Images\Gallery\2007");

            return View();
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

        public IActionResult Gallery2002()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            return View();
        }
    }
}
