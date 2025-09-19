using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class GaleryController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: Galery
        public ActionResult Index()
        {
            var values = db.Photo.ToList();
            return View(values);
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
    }
}