using BerkanPortfolyo.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class LoginController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin t)
        {
            var adminBilgiler = db.Admin.FirstOrDefault(x => x.NickName == t.NickName && x.Password == t.Password);

            if (adminBilgiler != null)
            {
                // Admin kullanıcı bilgilerini session'a kaydet
                Session["UserName"] = adminBilgiler.NickName;
                Session["UserId"] = adminBilgiler.Id; // ID'yi de tutmak faydalı olabilir

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // Hatalı giriş durumunda login sayfasına dön
                ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre.";
                return View();
            }
        }
    }
}