using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjecCV.Models.Entity;
using ProjecCV.Models.Sinif;

namespace ProjecCV.Controllers
{
    public class KonferansController : Controller
    {
        // GET: Konferans
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(string p)
        {
            var aranacakdeger = from aramadeger in db.TBLAWARDS select aramadeger;
            if(!string.IsNullOrEmpty(p))
            {
                aranacakdeger = aranacakdeger.Where(m => m.AWARD.Contains(p));
            }
            //Class1 cs = new Class1();
            //cs.Deger6 = db.TBLAWARDS.ToList();
            return View(aranacakdeger.ToList());
        }
        [HttpGet]
        public ActionResult YeniKonferans()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKonferans(TBLAWARDS p)
        {
            db.TBLAWARDS.Add(p);
            db.SaveChanges();
            return View(p);
        }
        public ActionResult Sil(int id)
        {
            var konferans = db.TBLAWARDS.Find(id);
            db.TBLAWARDS.Remove(konferans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KonferansGetir(int id)
        {
            var konferans = db.TBLAWARDS.Find(id);
            return View("KonferansGetir", konferans);
        }
        public ActionResult Guncelle(TBLAWARDS p)
        {
            var konferanslar = db.TBLAWARDS.Find(p.ID);
            konferanslar.AWARD = p.AWARD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}