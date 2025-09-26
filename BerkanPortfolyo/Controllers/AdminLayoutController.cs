using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class AdminLayoutController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult MessagesNotification()
        {
            var values = db.Contact.OrderByDescending(x=>x.ID).Take(5).ToList();
            return PartialView(values);
        }
    }
}