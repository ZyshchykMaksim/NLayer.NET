using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NLayer.Common;
using NLayer.Logging;
using NLayer.NET.BLL.Modals;
using NLayer.NET.BLL.Services;

namespace NLayer.NET.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExternalDataService externalDataService;
        private readonly ILog<AccountController> logService;

        public HomeController(IExternalDataService externalDataService, ILogFactory logFactory)
        {
            this.externalDataService = externalDataService;
            logService = logFactory.CreateLogger<AccountController>();
        }

        public ActionResult Index()
        {
            logService.Info("GET HomeController.Index");

            ResultModel<IList<ExternalDataDTO>> externalDatas = externalDataService.GetUsers();
            ResultModel<ExternalDataDTO> externalData = externalDataService.GetUser(Guid.NewGuid());
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