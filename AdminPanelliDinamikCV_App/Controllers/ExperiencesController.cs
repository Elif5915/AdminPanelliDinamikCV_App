
using AdminPanelliDinamikCV_App.Models.Entity;
using AdminPanelliDinamikCV_App.Repositories;
using System.Web.Mvc;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences

        ExperienceRepository experience = new ExperienceRepository();
        public ActionResult Index()
        {
            var exp = experience.List();
            return View(exp);
        }
        [HttpGet]
        public ActionResult ExpAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExpAdd(Experiences p)
        {
            experience.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult ExpDelete(int id)
        {
            Experiences deneyim = experience.Find(x => x.Id == id);
            experience.TDelete(deneyim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ExpGet(int id)
        {
            Experiences deneyim = experience.Find(x => x.Id == id);
            return View(deneyim);
        }

        [HttpPost]
        public ActionResult ExpGet(Experiences exp)
        {
            Experiences deneyim = experience.Find(x => x.Id == exp.Id);
            deneyim.Title = exp.Title;
            deneyim.Subhead = exp.Subhead;
            deneyim.Comment = exp.Comment;
            deneyim.Date = exp.Date;
            experience.TUpdate(deneyim);
            return RedirectToAction("Index");
        }
    }
}