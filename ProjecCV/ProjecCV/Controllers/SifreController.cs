using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjecCV.Models.Entity;
using ProjecCV.Models.Sinif;

namespace ProjecCV.Controllers
{
    public class SifreController : Controller
    {
        DbMvcCvEntities db = new DbMvcCvEntities();
        // GET: Sifre
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger7 = db.TBLUSERS.ToList();
            return View(cs);
        }
        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBLUSERS.Find(id);
            return View("VeriGetir", veriler);
        }
        public ActionResult Guncelle(TBLUSERS p)
        {
            var veri = db.TBLUSERS.Find(p.ID);
            veri.USERNAME = p.USERNAME;
            veri.PASSWORD = p.PASSWORD;
            veri.ROLE = p.ROLE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}