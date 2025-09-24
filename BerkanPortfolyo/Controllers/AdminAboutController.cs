using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class AdminAboutController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: AdminAbout
        public ActionResult Index()
        {
            var values  = db.About.FirstOrDefault();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.About.Find(id);
            return View("UpdateAbout", values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About t)
        {
            var value = db.About.Find(t.ID);

            value.PhotoUrl = t.PhotoUrl;
            value.Name = t.Name;
            value.Job  = t.Job;
            value.SocialiconUrl = t.SocialiconUrl;
            value.SocialiconUrl2 = t.SocialiconUrl2;
            value.SocialiconUrl3 = t.SocialiconUrl3;
            value.Sociallink1 = t.Sociallink1;
            value.Sociallink2 = t.Sociallink2;
            value.Sociallink3 = t.Sociallink3;
            value.WhoisMe = t.WhoisMe;
            value.WhoisMeDescription = t.WhoisMeDescription;

            db.SaveChanges();
            return RedirectToAction("Index");


        }
       
    }
}