using System;
using System.Web.Mvc;

namespace PageTransitions.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult HistoryView(string name, object model)
        {
            if (Request.IsAjaxRequest())
                return PartialView(name, model);
            else
                return View(name, model);
        }
    }
}
