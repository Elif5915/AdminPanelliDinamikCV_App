using AdminPanelliDinamikCV_App.Repositories;
using AdminPanelliDinamikCV_App.Models.Entity;
using System.Web.Mvc;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class AboutController : Controller
    {
        DbCvSitesiEntities db = new DbCvSitesiEntities();
        GenericRepository<About> repo = new GenericRepository<About>();

        [HttpGet]
        public ActionResult Index()
        {
            var hak = repo.List();
            return View(hak);
        }

        [HttpPost]
        public ActionResult Index(About about)
        {
            var hak = repo.Find(x => x.Id == 1);
            hak.Name = about.Name;
            hak.Surname = about.Surname;
            hak.Address = about.Address;
            hak.Phone = about.Phone;
            hak.Email = about.Email;
            hak.Comment = about.Comment;
            hak.Image = about.Image;
            repo.TUpdate(hak);
            return RedirectToAction("Index");
        }
    }
}