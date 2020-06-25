using ProjecCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjecCV.Controllers
{
    [AllowAnonymous]
   
    public class SecurityController : Controller
    {
        // GET: Security
        DbMvcCvEntities db = new DbMvcCvEntities();
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLUSERS kullanici)
        {
            var kullaniciInDb = db.TBLUSERS.FirstOrDefault(x => x.USERNAME == kullanici.USERNAME && x.PASSWORD == kullanici.PASSWORD);
            if (kullaniciInDb!=null)
            {
                if (kullaniciInDb.ROLE == "admin")
                {
                    FormsAuthentication.SetAuthCookie(kullaniciInDb.USERNAME, false);
                    return RedirectToAction("Index", "Hakkimda");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(kullaniciInDb.USERNAME, false);
                    return RedirectToAction("Index","Default");
                }
                
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}