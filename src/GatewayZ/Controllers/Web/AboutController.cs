using Microsoft.AspNetCore.Mvc;
using GatewayZ.GatewayZDAO;
using Microsoft.AspNetCore.Http;

namespace GatewayZ.Controllers.Web
{
    public class AboutController : Controller
    {
        private UserDAO _userDAO;

        public AboutController()
        {
            _userDAO = new UserDAO();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            

            if (ViewBag.Email != null)
            {
                ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);
                ViewBag.DisplayName = _userDAO.RetrieveUserDisplay(ViewBag.Email);
            }

            return View("About");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Logout", "App", new { area = "" });
        }
    }
}
