using GatewayZ.GatewayZDAO;
using GatewayZ.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;

namespace GatewayZ.Controllers.Web
{
    public class AppController : Controller
    {
        protected static MongoClient _client;
        protected static IMongoDatabase _database;
        private UserDAO _userDAO;
        private EventDAO _eventDAO;

        public AppController()
        {
            _client = new MongoClient("mongodb://gatewayz:370zNismo@ds044229.mlab.com:44229/gatewayz");
            _database = _client.GetDatabase(("gatewayz"));
            _userDAO = new UserDAO();
            _eventDAO = new EventDAO();
        }

        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            

            if (ViewBag.Email != null)
            {
                ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
                ViewBag.Events = _eventDAO.GetTopFiveEvents().ToList();
            }

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
    }
}