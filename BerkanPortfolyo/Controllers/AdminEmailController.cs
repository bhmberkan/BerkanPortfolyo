using BerkanPortfolyo.Models.Entity;
using MimeKit.Tnef;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class AdminEmailController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: AdminEmail
        public ActionResult Index(int sayfa =1)
        {
            var values = db.Contact
                    .OrderBy(x => x.ID) 
                    .ToPagedList(sayfa, 10);
            return View(values);
        }

        public ActionResult EmailDetail(int id)
        {
            var value = db.Contact.Find(id);
            if (value == null)
            {
                return HttpNotFound();
            }
            return PartialView("EmailDetail", value);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var value = db.Contact.Find(id);
            if (value != null)
            {
                db.Contact.Remove(value);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}