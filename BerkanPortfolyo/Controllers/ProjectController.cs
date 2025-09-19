using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class ProjectController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: Project
        public ActionResult Index()
        {
            var values = db.Project.ToList();
            return View(values);
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
    }
}