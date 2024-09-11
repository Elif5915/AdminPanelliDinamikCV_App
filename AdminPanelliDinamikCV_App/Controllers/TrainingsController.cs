using AdminPanelliDinamikCV_App.Models.Entity;
using AdminPanelliDinamikCV_App.Repositories;
using System.Web.Mvc;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class TrainingsController : Controller
    {
        GenericRepository<Trainings> repo = new GenericRepository<Trainings>();
        public ActionResult Index()
        {
            var edu = repo.List();
            return View(edu);
        }

        [HttpGet]
        public ActionResult addEdu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addEdu(Trainings t)
        {
            if (!ModelState.IsValid) //eğer modelin durum geçerliliği sağlanmadıysa yeni kayıt ekleme, aşağıdak kod operasyonu çalışmasın.
            {
                return View("addEdu"); // eğitim ekleme view geri dönsün, bir şey yapmasın demek istiyoruz aslında
            }
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult EduDelete(int id)
        {
            var edu = repo.Find(x => x.Id == id);
            repo.TDelete(edu);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateEdu(int id)
        {
            var edu = repo.Find(x => x.Id == id);
            return View(edu);
        }

        [HttpPost]
        public ActionResult UpdateEdu(Trainings t)
        {
            if (!ModelState.IsValid) //eğer modelin durum geçerliliği sağlanmadıysa yeni kayıt ekleme, aşağıdak kod operasyonu çalışmasın.
            {
                return View("UpdateEdu"); // eğitim ekleme view geri dönsün, bir şey yapmasın demek istiyoruz aslında
            }
            var edu = repo.Find(x => x.Id == t.Id);
            edu.Title = t.Title;
            edu.SubTitle = t.SubTitle;
            edu.SubTitle2 = t.SubTitle2;
            edu.Gno = t.Gno;
            edu.Date = t.Date;
            repo.TUpdate(edu);
            return RedirectToAction("Index");

        }
    }
}