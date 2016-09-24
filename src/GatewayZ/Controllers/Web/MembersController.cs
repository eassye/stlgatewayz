using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GatewayZ.GatewayZDAO;

namespace GatewayZ.Controllers.Web
{
    public class MembersController : Controller
    {
        private UserDAO _userDAO;

        public MembersController()
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

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "App", new { area = "" });
        }
    }
}
