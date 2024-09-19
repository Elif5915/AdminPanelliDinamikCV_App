using AdminPanelliDinamikCV_App.Models.Entity;
using System.Web.Mvc;
using AdminPanelliDinamikCV_App.Repositories;
using System.Linq;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();
 
        public ActionResult Index()
        {
            var sMedia = repo.List();
            return View(sMedia);
        }

        [HttpGet]
        public ActionResult newSocialMedia()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult newSocialMedia(SocialMedia sm)
        {
            repo.TAdd(sm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult updateSocial(int id)
        {
            var hesap = repo.Find(x => x.Id == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult updateSocial(SocialMedia sm)
        {
            var hesap = repo.Find(x => x.Id == sm.Id);
            
            hesap.Name = sm.Name;
            hesap.Link = sm.Link;
            hesap.Icon = sm.Icon;
            hesap.Status = true;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult deleteSocial(int id)
        {
            var hesap = repo.Find(x => x.Id == id);
            hesap.Status = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}