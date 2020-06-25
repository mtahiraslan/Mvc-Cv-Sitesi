using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjecCV.Models.Entity;
using ProjecCV.Models.Sinif;

namespace ProjecCV.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger5 = db.TBLINTERESTS.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHobi(TBLINTERESTS p)
        {
            db.TBLINTERESTS.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var hobi = db.TBLINTERESTS.Find(id);
            db.TBLINTERESTS.Remove(hobi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HobiGetir(int id)
        {
            var hobi = db.TBLINTERESTS.Find(id);
            return View("HobiGetir", hobi);
        }
        public ActionResult Guncelle(TBLINTERESTS p)
        {
            var hobiler = db.TBLINTERESTS.Find(p.ID);
            hobiler.INTEREST = p.INTEREST;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}