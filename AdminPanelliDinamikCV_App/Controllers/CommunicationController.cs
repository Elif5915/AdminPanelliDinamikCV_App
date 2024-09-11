using AdminPanelliDinamikCV_App.Models.Entity;
using System.Web.Mvc;
using AdminPanelliDinamikCV_App.Repositories;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class CommunicationController : Controller
    {
        GenericRepository<Communication> repo = new GenericRepository<Communication>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}