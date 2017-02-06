using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayer.NET.BLL;
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
            IList<UserModel> users = _userService.GetUsers();
            return View();
        }
    }
}