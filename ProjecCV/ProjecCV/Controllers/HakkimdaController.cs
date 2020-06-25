using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjecCV.Models.Entity;
using ProjecCV.Models.Sinif;

namespace ProjecCV.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLABOUT.ToList();
            return View(cs);
        }
        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBLABOUT.Find(id);
            return View("VeriGetir", veriler);
        }
        public ActionResult Guncelle(TBLABOUT p)
        {
            var degerler = db.TBLABOUT.Find(p.ID);
            degerler.NAME = p.NAME;
            degerler.SURNAME = p.SURNAME;
            degerler.ADDRESS = p.ADDRESS;
            degerler.PHONE = p.PHONE;
            degerler.MAIL = p.MAIL;
            degerler.ABOUT = p.ABOUT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}