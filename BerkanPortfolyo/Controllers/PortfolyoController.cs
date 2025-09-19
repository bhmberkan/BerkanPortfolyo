using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class PortfolyoController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: Portfolyo
        public ActionResult Index()
        {
            var values = db.Portfolio.ToList();
            return View(values);
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
    }
}