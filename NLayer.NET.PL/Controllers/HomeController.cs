using System.Collections.Generic;
using System.Web.Mvc;
using NLayer.NET.BLL.Modals;
using NLayer.NET.BLL.Services;

namespace NLayer.NET.PL.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Home
        public ActionResult Index()
        {
            IList<UserDTO> users = _userService.GetUsers();
            return View();
        }
    }
}