using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_Project.Models.Siniflar;
namespace Travel_Project.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            // var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();//İlk 3 blogun listesini al.
            by.Deger2 = c.Yorumlars.Take(3).ToList();//3yorumu al.
            return View(by);

        }

        public ActionResult BlogDetay(int id)
        {

            //   var blogbul = c.Blogs.Where(x => x.ID==id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;//blogidsine göre yorumların alınmaısnı sağlayaacak.
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);//bden gelen değeri yorumların içine ekle.
            c.SaveChanges();
            return PartialView();
        }

    }
}