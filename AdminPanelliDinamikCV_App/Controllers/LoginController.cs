using AdminPanelliDinamikCV_App.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminPanelliDinamikCV_App.Controllers
{
    //global asax tüm proje bazlı authorize ekledik ama login sayfamıza da giremiyoruz. ama buraya bizim ulaşmamız gerek, bu login controlleri istisna yapmak için aşağıdaki 
    // attribute ekliyoruz.
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            DbCvSitesiEntities db = new DbCvSitesiEntities();
            var adminInfo = db.Admin.FirstOrDefault( x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
                Session["UserName"] = adminInfo.UserName.ToString();
                return RedirectToAction("Index", "Experiences");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();  // oturum açmış kullanıcının oturumunu sonlandırmak için kullanılır.
            Session.Abandon();  //session terket anlamında. mevcut oturum sonlandırılır,oturum verileri sunucu tarafından temizlenir taki yeni bir oturum başlatılana kadar
            return RedirectToAction("Index", "Login");
        }
    }
}