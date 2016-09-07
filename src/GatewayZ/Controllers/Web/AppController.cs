using GatewayZ.GatewayZDAO;
using GatewayZ.Models;
using GatewayZ.Services;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using MongoDB.Driver;
using System;
using System.Linq;

namespace GatewayZ.Controllers.Web
{
    public class AppController : Controller
    {
        protected static IMongoClient _client;
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

            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);

                //string password = "Pa$$w0rd";
                //Crypto _crypto = new Crypto();
                //string encrpyTxt = _crypto.EncryptString(ViewBag.Password, password);
                //string decryptTxt = _crypto.DecryptString(encrpyTxt, password);
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

        public IActionResult About()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            return View();
        }

        public IActionResult Events()
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
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedUser");
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
        public IActionResult Events([Bind]Event events)
        {
            if (ModelState.IsValid)
            {
                events.StartDate.ToString();
                _eventDAO.SaveEvent(events);
                return RedirectToAction("Events");
            }

            return View();
        }

        public IActionResult Register()
        {
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind]User user)
        {
            if (ModelState.IsValid)
            {
                var collection = _database.GetCollection<User>("User");

                collection.InsertOneAsync(user);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Gallery()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            return View();
        }

        public IActionResult Members()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            return View();
        }

        public IActionResult History()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

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
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            string authUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (authUser == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedUser");
            }
        }

        [HttpPost]
        public IActionResult Admin(AdminPageModel _data)
        {
            var _adminService = new AdminServices();

            _adminService.ProcessUpdate(_data);

            return RedirectToAction("Admin");
        }

        public IActionResult Gallery2002()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            return View();
        }

        public IActionResult Gallery2003CarShow()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            var file = new HistoryServices();

            string filePath = @"Images\Gallery\2003";

            ViewBag.fileName = file.FileName(filePath);

            return View();
        }

        public IActionResult EditUser()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            return View();
        }

        [HttpPost]
        public IActionResult EditUser(User _user)
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            var _service = new EditUserServices(_userDAO);

            _service.ProcessUpdate(_user, ViewBag.Email);

            return RedirectToAction("EditUser");
        }

        public IActionResult RecoverPassword()
        {
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            return View();
        }

        [HttpPost]
        public IActionResult RecoverPassword([Bind]User _user)
        {
            var _service = new EditUserServices(_userDAO);

            _service.UpdateUserPassword(_user);

            return RedirectToAction("RecoverPassword");
        }

        public IActionResult UnauthorizedUser()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            return View();
        }
    }
}