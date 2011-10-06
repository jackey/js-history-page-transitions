using System;
using System.Web.Mvc;

namespace PageTransitions.Controllers
{
    public class HistoryjsController : SharedController
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

            if (this.Request.IsAjaxRequest())
                return PartialView(peep);

            return HistoryView("View", peep);
        }

        public ActionResult NormalNonFunkyView()
        {
            return HistoryView("NormalNonFunkyView", null);
        }
    }
}
