using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Travel_Project.Models.Siniflar;

namespace Travel_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost] //Sayfada veri gönderme işlemi olduğu zaman bu controller çalışacak.
        public ActionResult Login(Admin adm)//Admin sınıfından parametre döbdürecek.
        {
            //Önce kullanıcı adı ve sifre kontolü yapan linq sorguları
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == adm.Kullanici && x.Sifre == adm.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);//bilgilere göre kullanıcıyı sisteme alıyoruz.
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return  RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();

            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();//Oturumu kapat.
            return RedirectToAction("Login", "Login");
        }
    }
}