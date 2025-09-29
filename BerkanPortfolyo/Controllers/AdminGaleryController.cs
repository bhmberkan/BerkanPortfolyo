using BerkanPortfolyo.Controllers;
using BerkanPortfolyo.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanGalery.Controllers
{
    public class AdminGaleryController : BaseController
    {
        // GET: AdminGalery
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: AdminGalery
        public ActionResult Index(int sayfa =1)
        {
            var values = db.Photo.OrderBy(x=>x.Id).ToPagedList(sayfa,10);
            return View(values);
        }



        [HttpGet]
        public ActionResult CreateAdminGalery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdminGalery(Photo t)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAdminGalery");
            }
            db.Photo.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");

        }




        [HttpGet]
        public ActionResult UpdateGalery(int id)
        {
            var values = db.Photo.Find(id);
            return View("UpdateGalery", values);
        }
        [HttpPost]
        public ActionResult UpdateGalery(Photo t)
        {
            var value = db.Photo.Find(t.Id);
          
            value.PhotoUrl = t.PhotoUrl;


            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DeleteGalery(int id)
        {
            var prt = db.Photo.Find(id);
            db.Photo.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminGalery");
        }
    }
}