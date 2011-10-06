using System;
using System.Web.Mvc;
using System.Web;

namespace PageTransitions.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult HistoryView(string name, object model)
        {
            if (Request.IsAjaxRequest())
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.AppendHeader("Cache-Control", "no-cache");
                return PartialView(name, model);
            }
            else
            {
                return View(name, model);
            }
        }
    }
}
