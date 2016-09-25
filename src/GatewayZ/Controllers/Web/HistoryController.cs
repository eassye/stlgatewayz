using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using GatewayZ.Services;
using Microsoft.AspNetCore.Hosting.Internal;

namespace GatewayZ.Controllers.Web
{
    public class HistoryController : Controller
    {
        private UserDAO _userDAO;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HistoryController()
        {
            _userDAO = new UserDAO();
            _hostingEnvironment = new HostingEnvironment();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
            {
                _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            string webRoot = _hostingEnvironment.WebRootPath;


            if (ViewBag.Email != null)
            {
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            var _service = new HistoryServices();

            ViewBag.fileCount2002Folder = _service.CountFiles(webRoot + @"\Images\Gallery\2002");
            ViewBag.file2002ModifiedDate = _service.LastDateModified(webRoot + @"\Images\Gallery\2002");

            ViewBag.fileCount2003Folder = _service.CountFiles(webRoot + @"\Images\Gallery\2003");
            ViewBag.file2003ModifiedDate = _service.LastDateModified(webRoot + @"\Images\Gallery\2003");

            ViewBag.fileCount2004Folder = _service.CountFiles(webRoot + @"\Images\Gallery\2004");
            ViewBag.file2004ModifiedDate = _service.LastDateModified(webRoot + @"\Images\Gallery\2004");

            ViewBag.fileCount2005Folder = _service.CountFiles(webRoot + @"\Images\Gallery\2005");
            ViewBag.file2005ModifiedDate = _service.LastDateModified(webRoot + @"\Images\Gallery\2005");

            ViewBag.fileCount2006Folder = _service.CountFiles(webRoot + @"\Images\Gallery\2006");
            ViewBag.file2006ModifiedDate = _service.LastDateModified(webRoot + @"\Images\Gallery\2006");

            //ViewBag.fileCount2007Folder = _service.CountFiles(@"Images\Gallery\2007");
            //ViewBag.file2007ModifiedDate = _service.LastDateModified(@"Images\Gallery\2007");

            return View("History");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "App", new { area = "" });
        }
    }
}
