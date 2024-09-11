using AdminPanelliDinamikCV_App.Models.Entity;
using System.Web.Mvc;
using AdminPanelliDinamikCV_App.Repositories;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class HobbiesController : Controller
    {
        GenericRepository<Hobbies> repo = new GenericRepository<Hobbies>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobi = repo.List();
            return View(hobi);
        }

        [HttpPost]
        public ActionResult Index(Hobbies h)
        {
            // Hobbies hobi = new Hobbies();
            var deger = repo.Find(x => x.Id == 1);
            deger.Hobby = h.Hobby;
            deger.Hobby2 = h.Hobby2;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}