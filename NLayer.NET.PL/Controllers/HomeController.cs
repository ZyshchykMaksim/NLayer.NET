using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NLayer.NET.BLL.Modals;
using NLayer.NET.BLL.Services;
using NLayer.NET.Common.Intarfeces;

namespace NLayer.NET.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Home
        public ActionResult Index()
        {
            IResult<IList<UserDTO>> users = _userService.GetUsers();
            IResult<UserDTO> user = _userService.GetUser(Guid.NewGuid());
            IResult<bool> isUser = _userService.Exists(Guid.NewGuid());

            return View();
        }
    }
}