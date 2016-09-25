using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using GatewayZ.Services;
using System.IO;

namespace GatewayZ.Controllers.Web
{
    public class Gallery2003CarShowController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private UserDAO _userDAO;

        public Gallery2003CarShowController()
        {
            _hostingEnvironment = new HostingEnvironment();
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

            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
            {
                _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            string webRoot = _hostingEnvironment.WebRootPath;

            var file = new HistoryServices();

            string filePath = webRoot + @"\Images\Gallery\2003";

            ViewBag.fileName = file.FileName(filePath);

            return View("Gallery2003CarShow");
        }
    }
}
