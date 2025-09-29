using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkanPortfolyo.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Eğer Session boşsa
            if (Session["NickName"] == null)
            {
                // Login sayfasına yönlendir
                filterContext.Result = new RedirectResult("~/Login/Index/");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}