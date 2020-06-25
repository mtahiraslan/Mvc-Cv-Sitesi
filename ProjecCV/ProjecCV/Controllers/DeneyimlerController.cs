using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjecCV.Models.Entity;
using ProjecCV.Models.Sinif;

namespace ProjecCV.Controllers
{
    
    public class DeneyimlerController : Controller
    {
        // GET: Deneyimler
        DbMvcCvEntities db = new DbMvcCvEntities();
        
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger2 = db.TBLEXPERIENCE.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult YeniDeneyim()

        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDeneyim(TBLEXPERIENCE p)
        {
            db.TBLEXPERIENCE.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeneyimSil(int id)
        {
            var deneyim = db.TBLEXPERIENCE.Find(id);
            db.TBLEXPERIENCE.Remove(deneyim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimGetir(int id)
        {
            var veri = db.TBLEXPERIENCE.Find(id);
            return View("DeneyimGetir",veri);
        }
        public ActionResult Guncelle(TBLEXPERIENCE p)
        {
            var veriler = db.TBLEXPERIENCE.Find(p.ID);
            veriler.TITLE = p.TITLE;
            veriler.SUBTITLE = p.SUBTITLE;
            veriler.DETAILS = p.DETAILS;
            veriler.DATE = p.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}