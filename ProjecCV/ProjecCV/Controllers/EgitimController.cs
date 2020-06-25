using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjecCV.Models.Entity;
using ProjecCV.Models.Sinif;

namespace ProjecCV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger3 = db.TBLEDUCATION.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniEgitim(TBLEDUCATION p)
        {
            db.TBLEDUCATION.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var egt = db.TBLEDUCATION.Find(id);
            db.TBLEDUCATION.Remove(egt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EgitimGetir(int id)
        {
            var egitim = db.TBLEDUCATION.Find(id);
            return View("EgitimGetir",egitim);
        }
        public ActionResult Guncelle(TBLEDUCATION p)
        {
            var degerler = db.TBLEDUCATION.Find(p.ID);
            
            degerler.TITLE = p.TITLE;
            degerler.SUBTITLE = p.SUBTITLE;
            degerler.DEPARTMENT = p.DEPARTMENT;
            degerler.GPA = p.GPA;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}