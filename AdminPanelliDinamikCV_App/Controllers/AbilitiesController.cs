using System.Web.Mvc;
using AdminPanelliDinamikCV_App.Models.Entity;
using AdminPanelliDinamikCV_App.Repositories;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class AbilitiesController : Controller
    {
        // DbCvSitesiEntities db = new DbCvSitesiEntities();
        GenericRepository<Abilities> repo = new GenericRepository<Abilities>();
        public ActionResult Index()
        {
            // var ytnk = db.Abilities.ToList();
            var ytnk = repo.List();
            return View(ytnk);
        }
        [HttpGet]
        public ActionResult newAbilities()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newAbilities(Abilities p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult deleteAbilities(int id)
        {
            var app = repo.Find(x => x.Id == id);
            repo.TDelete(app);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult updateAbilities(int id)
        {
            var app = repo.Find(x => x.Id == id);
            return View(app);
        }

        [HttpPost]
        public ActionResult updateAbilities(Abilities a)
        {
            var app = repo.Find(x => x.Id == a.Id);
            app.Talent = a.Talent;
            app.Rate = a.Rate;
            repo.TUpdate(app);
            return RedirectToAction("Index");
        }
    }
}