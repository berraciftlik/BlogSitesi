using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_Project.Models.Siniflar;

namespace Travel_Project.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]//Sayfanın boş halinin döndür.
        public ActionResult YeniBlog()//2 tane yapmamızın sebebi birinin http get birinin http postta çalışacak.
        {
            return View();
        }
        [HttpPost]//Sayfada bir işlem yapıldığında bunu döndür.
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);//p den gelen değerleri tabloya ekle.pnin değerleri de formdan gelecek.
            c.SaveChanges();//değişiklikleri kaydet.
            return RedirectToAction("Index");//Index actıona yönlendir.
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);//idye göre tablodan bilgileri bul.
            c.Blogs.Remove(b);//b den gelen değeri kaldır.
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)//Id'ye uygun olan bilgileri bulup getirecek.
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir", blog);//Bloggetir sayfası ve burdaki değişkenleri getir.
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var bl = c.Blogs.Find(b.ID);//Gönderdiğimiz b ye göre idyi bul.
            bl.Aciklama = b.Aciklama;//Yeni açıklamayı al.
            bl.Baslik = b.Baslik;//Yeni başlığı al.
            bl.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View (yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);//idye göre tablodan bilgileri bul.
            c.Yorumlars.Remove(b);//b den gelen değeri kaldır.
            c.SaveChanges();
            return RedirectToAction("Admin/YorumListesi");
        }
        public ActionResult YorumGetir(int id)//Id'ye uygun olan bilgileri bulup getirecek.
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir", yorum);//Bloggetir sayfası ve burdaki değişkenleri getir.
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);//Gönderdiğimiz b ye göre idyi bul.
            yrm.KullaniciAdi = y.KullaniciAdi;//Yeni açıklamayı al.
            yrm.Yorum = y.Yorum;//Yeni başlığı al.
            yrm.Mail = y.Mail;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}