using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class AdminController : BaseController
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: Admin
        // main için kullanıyorum burayı
        public ActionResult Index()
        {
            var values = db.Main.FirstOrDefault();
            return View(values);
        }



        [HttpGet]
        public ActionResult UpdateMain(int id)
        {
            var values = db.Main.Find(id);
            return View("UpdateMain", values);
        }
        [HttpPost]
        public ActionResult UpdateMain(Main t)
        {
            var value = db.Main.Find(t.Id);
            value.title1 = t.title1;
            value.title2 = t.title2;
            value.title2 = t.title2;
            value.photo1 = t.photo1;
            value.photo2 = t.photo2;
            value.photo3 = t.photo3;
            value.ptitle = t.ptitle;
            value.pdescription = t.pdescription;


            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}