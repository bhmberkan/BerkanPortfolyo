using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class AdminSettingsController : BaseController
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: AdminSettings
        public ActionResult Index()
        {
            var values = db.Admin.FirstOrDefault();
            return View(values);
        }



        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var values = db.Admin.Find(id);
            return View("UpdateAdmin", values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin t)
        {
            var value = db.Admin.Find(t.Id);
            value.NickName = t.NickName;
            value.Password = t.Password;
            


            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}