using Microsoft.AspNetCore.Mvc;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Http;

namespace GatewayZ.Controllers.Web
{
    public class UnauthorizedUserController : Controller
    {
        private UserDAO _userDAO;

        public UnauthorizedUserController()
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

            return View("UnauthorizedUser");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "App", new { area = "" });
        }
    }
}
