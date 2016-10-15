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
            var isEmailRegistered = _userDAO.IsEmailRegistered(user.email);

            if (ModelState.IsValid)
            {
                if (isEmailRegistered == true)
                {
                    TempData["EmailExist"] = "Email already exist. Please choose another email.";
                    //return RedirectToAction("Index");
                    return View("Register");
                }

                user.userType = "RegisteredUser";

                var collection = _database.GetCollection<User>("User");
                
                collection.InsertOneAsync(user);
                TempData["Success"] = "User Account: " + user.displayName + " has been created!";
                return RedirectToAction("Index");
            }

            return View("Register");
        }
    }
}
