using BerkanPortfolyo.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class AdminPortfolyoController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: AdminPortfolyo
        public ActionResult Index(int sayfa=1)
        {
            var values = db.Portfolio.OrderBy(x => x.Id).ToPagedList(sayfa, 10);
            return View(values);
        }


        
        [HttpGet]
        public ActionResult CreateAdminPortfolyo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdminPortfolyo(Portfolio t)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAdminPortfolyo");
            }
            db.Portfolio.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");

        }




        [HttpGet]
        public ActionResult UpdatePortfolyo(int id)
        {
            var values = db.Portfolio.Find(id);
            return View("UpdatePortfolyo", values);
        }
        [HttpPost]
        public ActionResult UpdatePortfolyo(Portfolio t)
        {
            var value = db.Portfolio.Find(t.Id);
            value.Title= t.Title;
            value.SubTitle = t.SubTitle;
            value.Description= t.Description;
            value.PhotoUrl = t.PhotoUrl;
           

            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DeletePortfolyo(int id)
        {
            var prt = db.Portfolio.Find(id);
            db.Portfolio.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminPortfolyo");
        }
        


    }
}