using System.Web.Mvc;
using AdminPanelliDinamikCV_App.Models.Entity;
using AdminPanelliDinamikCV_App.Repositories;

namespace AdminPanelliDinamikCV_App.Controllers
{
   // [AllowAnonymous]
    public class AdminController : Controller
    {
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var adminList = repo.List();
            return View(adminList);
        }

        [HttpGet]
        public ActionResult adminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminAdd(Admin admin)
        {
            repo.TAdd(admin);
            return RedirectToAction("Index");
        }

        public ActionResult adminDelete(int id)
        {
            Admin user = repo.Find(x => x.Id == id);
            repo.TDelete(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult adminUpdate(int id)
        {
            Admin user = repo.Find(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult adminUpdate(Admin admin)
        {
            Admin user = repo.Find(x => x.Id == admin.Id);
            user.UserName = admin.UserName;
            user.Password =admin.Password;
            repo.TUpdate(user);
            return RedirectToAction("Index");
        }
    }
}