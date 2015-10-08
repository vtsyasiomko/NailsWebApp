using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NailsWebApp.Data.DAL;

namespace NailsWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var entity = new AppNailsDbContext();

            var citys = entity.Citys.Where(c => c.CityName == "");

            ViewBag.Citys = citys;

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