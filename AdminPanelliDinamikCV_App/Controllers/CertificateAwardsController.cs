using AdminPanelliDinamikCV_App.Repositories;
using System.Web.Mvc;
using AdminPanelliDinamikCV_App.Models.Entity;
using System.Linq;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class CertificateAwardsController : Controller
    {
        GenericRepository<CertificateAwards> repo = new GenericRepository<CertificateAwards>();
        public ActionResult Index()
        {
            var cerAward = repo.List();
            return View(cerAward);
        }
        [HttpGet]
        public ActionResult CerAwardGet(int id)
        {
            var cerAward = repo.Find(x => x.Id == id);
            ViewBag.d = id;
            return View(cerAward);

        }
        [HttpPost]
        public ActionResult CerAwardGet(CertificateAwards ca)
        {
            var cerAward = repo.Find(x => x.Id == ca.Id);
            cerAward.Comment = ca.Comment;
            cerAward.Date = ca.Date;
            repo.TUpdate(cerAward);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CerAwardAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CerAwardAdd(CertificateAwards certificateAwards)
        {
            repo.TAdd(certificateAwards);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCerAward(int id)
        {
            var cerAward = repo.Find(x => x.Id == id);
            repo.TDelete(cerAward);
            return RedirectToAction("Index");
        }
    }
}