using Microsoft.AspNetCore.Mvc;
using GatewayZ.GatewayZDAO;
using GatewayZ.Models;
using GatewayZ.Services;

namespace GatewayZ.Controllers.Web
{
    public class RecoverPasswordController : Controller
    {
        private UserDAO _userDAO;

        public RecoverPasswordController()
        {
            _userDAO = new UserDAO();
        }
        public IActionResult Index()
        {
            ViewBag.AuthUser = _userDAO.RetrieveUserType(ViewBag.Email);

            return View("RecoverPassword");
        }

        [HttpPost]
        public IActionResult Index([Bind]User _user)
        {
            var _service = new EditUserServices(_userDAO);

            _service.UpdateUserPassword(_user);

            return RedirectToAction("Index");
        }
    }
}
