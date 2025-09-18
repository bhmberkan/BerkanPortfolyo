using BerkanPortfolyo.Models.Entity;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using System.Web.Services.Description;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace BerkanPortfolyo.Controllers
{
    public class AboutController : Controller
    {
        BBTPortfolyoEntities db = new BBTPortfolyoEntities();
        // GET: About
        public ActionResult Index()
        {
            var values = db.About.FirstOrDefault();
            return View(values);
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult Whoisme()
        {
            var value = db.About.FirstOrDefault();
            return PartialView(value);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult Contact(Contact t)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress(t.NameSurname, t.Mail);
            mimeMessage.From.Add(mailboxAddress); // mesaj kimden

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", "berkanburakturgut@gmail.com");
            mimeMessage.To.Add(mailboxAddressTo); // mesaj kime

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = t.Message + " \n \nGöndere: " + t.Mail; // içerik.
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = t.Title;

            
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); // 587 port numarası , ssl gereksin mi = fasle istersen true yaparsın
            client.Authenticate("berkanburakturgut@gmail.com", "brbrfhcxozglgegx");
            client.Send(mimeMessage);
            client.Disconnect(true);


            db.Contact.Add(t);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi. En kısa sürede size dönüş yapılacaktır.";

            ModelState.Clear();
            return PartialView(new Contact()); // boş model döndürüyorum ki sayfa temiz gelsin.
        }
    }
}