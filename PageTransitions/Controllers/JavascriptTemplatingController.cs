using System;
using System.Web.Mvc;
using System.Web;

namespace PageTransitions.Controllers
{
    public class JavascriptTemplatingController : SharedController
    {
        private PersonInfoRepository _repo = new PersonInfoRepository();

        public ActionResult Index()
        {
            var peeps = _repo.GetPersonInfoList();

            return HistoryView("Index", peeps);
        }

        public ActionResult Edit(int? id)
        {
            var peep = _repo.GetPerson(id.Value);

            return HistoryView("Edit", peep);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string name, int? age)
        {
            var peep = _repo.GetPerson(id.Value);
            peep.Name = name;
            if (age.HasValue)
                peep.Age = age.Value;

            _repo.SavePerson(peep);

            return HistoryView("View", peep);
        }

        public ActionResult View(int? id)
        {
            var peep = _repo.GetPerson(id.Value);
            return HistoryView("View", peep);
        }

        public ActionResult NormalNonFunkyView()
        {
            return HistoryView("NormalNonFunkyView", null);
        }

        public override ActionResult HistoryView(string name, object model)
        {
            if (Request.IsAjaxRequest())
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(name, model);
            }
        }
    }
}
