using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using GatewayZ.Services;
using Microsoft.AspNetCore.Http;

namespace GatewayZ.Controllers.Web
{
    public class Gallery2002Controller : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private UserDAO _userDAO;

        public Gallery2002Controller()
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

            string filePath = webRoot + @"\Images\Gallery\2002";

            ViewBag.fileName = file.FileName(filePath);

            return View("Gallery2002");
        }
    }
}
