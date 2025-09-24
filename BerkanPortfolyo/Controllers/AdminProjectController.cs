using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class AdminProjectController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: AdminProject
        public ActionResult Index()
        {
            var values = db.Project.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateAdminProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdminProject(Project t)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAdminProject");
            }
            db.Project.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");

        }




        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var values = db.Project.Find(id);
            return View("UpdateProject", values);
        }
        [HttpPost]
        public ActionResult UpdateProject(Project t)
        {
            var value = db.Project.Find(t.ID);

            value.Title = t.Title;
            value.SubTitle = t.SubTitle;    
            value.Description = t.Description;
            value.Date = t.Date;
            value.PhotoUrl = t.PhotoUrl;
            value.ProjecUrl = t.ProjecUrl;

            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DeleteProject(int id)
        {
            var prt = db.Project.Find(id);
            db.Project.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminProject");
        }
    }
}