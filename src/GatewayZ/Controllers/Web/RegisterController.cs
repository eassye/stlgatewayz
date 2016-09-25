using Microsoft.AspNetCore.Mvc;
using GatewayZ.GatewayZDAO;
using GatewayZ.Models;
using MongoDB.Driver;

namespace GatewayZ.Controllers.Web
{
    public class RegisterController : Controller
    {
        private UserDAO _userDAO;
        protected static MongoClient _client;
        protected static IMongoDatabase _database;

        public RegisterController()
        {
            _client = new MongoClient("mongodb://gatewayz:370zNismo@ds044229.mlab.com:44229/gatewayz");
            _database = _client.GetDatabase(("gatewayz"));
            _userDAO = new UserDAO();
        }

        public IActionResult Index()
        {
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);
            return View("Register");
        }

        [HttpPost]
        public IActionResult Index([Bind]User user)
        {
            if (ModelState.IsValid)
            {
                user.userType = "Registered";

                var collection = _database.GetCollection<User>("User");
                
                collection.InsertOneAsync(user);

                return RedirectToAction("Index");
            }

            return View("Register");
        }
    }
}
