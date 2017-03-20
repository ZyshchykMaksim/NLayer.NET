using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayer.NET.BLL.Logger;
using NLayer.NET.BLL.Modals;
using NLayer.NET.BLL.Services;
using NLayer.NET.Common.Intarfeces;

namespace NLayer.NET.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExternalDataService _externalDataService;
        private readonly ILog<AccountController> _logService;

        public HomeController(IExternalDataService externalDataService, ILogFactory logFactory)
        {
            _externalDataService = externalDataService;
            _logService = logFactory.CreateLogger<AccountController>();
        }

        public ActionResult Index()
        {
            _logService.Info("GET HomeController.Index");

            IResult<IList<ExternalDataDTO>> externalDatas = _externalDataService.GetUsers();
            IResult<ExternalDataDTO> externalData = _externalDataService.GetUser(Guid.NewGuid());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}