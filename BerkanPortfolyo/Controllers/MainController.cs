using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class MainController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: Main
        public ActionResult Index()
        {
            var values = db.Main.FirstOrDefault();
            return View(values);
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }



        public PartialViewResult SectionPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavBarPartial()
        {
            return PartialView();
        }
    }
}