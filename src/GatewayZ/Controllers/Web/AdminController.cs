using Microsoft.AspNetCore.Mvc;
using GatewayZ.Models;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Http;
using GatewayZ.Services;

namespace GatewayZ.Controllers.Web
{
    public class AdminController : Controller
    {
        private UserDAO _userDAO;

        public AdminController()
        {
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

            string authUser = _userDAO.RetrieveUserType(ViewBag.Email);

            if (authUser == "Admin")
            {
                return View("Admin");
            }
            else
            {
                return RedirectToAction("Index", "UnauthorizedUser", new { area = "" });
            }
        }

        [HttpPost]
        public IActionResult Index(AdminPageModel _data)
        {
            var _adminService = new AdminServices();

            _adminService.ProcessUpdate(_data);

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "App", new { area = "" });
        }
    }
}
