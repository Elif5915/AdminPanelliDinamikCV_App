using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanelliDinamikCV_App.Models.Entity;

namespace AdminPanelliDinamikCV_App.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvSitesiEntities dbCv = new DbCvSitesiEntities(); //nesne oluşturduk.
        public ActionResult Index()
        {
            var degerler = dbCv.About.ToList();

            return View(degerler);
        }

        public PartialViewResult Experience() //Deneyimler 
        {
            var exp = dbCv.Experiences.ToList();
            return PartialView(exp);
        }

        public PartialViewResult Education() //eğitimler
        {
            var edu = dbCv.Trainings.ToList();
            return PartialView(edu);
        }

        public PartialViewResult Abilities() //yeteneklerim
        {
            var yet = dbCv.Abilities.ToList();
            return PartialView(yet);
        }

        public PartialViewResult Hobbies() //hobilerim
        {
            var hobby = dbCv.Hobbies.ToList();
            return PartialView(hobby);
        }
        public PartialViewResult CertificateAwards() //sertifika/ödül
        {
            var cA = dbCv.CertificateAwards.ToList();
            return PartialView(cA);
        }

        [HttpGet]
        public PartialViewResult Communication() //iletiismbil
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Communication(Communication cm) //iletiismbil
        {
            cm.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            dbCv.Communication.Add(cm); //cm den gelen değerleri communicationa ekle
            dbCv.SaveChanges(); // değişiklikleri db kaydet 
            return PartialView(); //sonra bize partial viewi döndür 
        }
    }
}