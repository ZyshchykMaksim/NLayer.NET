using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NLayer.NET.BLL.Logger;
using NLayer.NET.BLL.Modals;
using NLayer.NET.BLL.Services;
using NLayer.NET.Common.Intarfeces;

namespace NLayer.NET.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILog<HomeController> _logService;

        public HomeController(IUserService userService, ILogFactory logFactory)
        {
            _userService = userService;
            _logService = logFactory.CreateLogger<HomeController>();
        }                
        
        
        // GET: Home
        public ActionResult Index()
        {
            _logService.Info("GET HomeController.Index");

            IResult<IList<UserDTO>> users = _userService.GetUsers();
            IResult<UserDTO> user = _userService.GetUser(Guid.NewGuid());
            IResult<bool> isUser = _userService.Exists(Guid.NewGuid());

            return View();           
        }
    }
}