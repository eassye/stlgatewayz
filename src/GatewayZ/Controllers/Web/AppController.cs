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

namespace GatewayZ.Controllers.Web
{
    public class AppController : Controller
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        public readonly MongoDBContext Context = new MongoDBContext();

        public AppController()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(("GatewayZ")); 
        }

        public IActionResult Index()
        {
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

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult BecomeAMember()
        {
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
            return View();
        }

        public IActionResult Members()
        {
            //var email = ClaimsPrincipal.Current.FindFirst("email").Value;

            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }
    }
}
