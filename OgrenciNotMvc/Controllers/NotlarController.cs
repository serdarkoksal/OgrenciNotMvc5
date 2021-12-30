using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        
        public ActionResult Index()
        {
            var SinavNotlar = db.TBLNOTLAR.ToList();
            return View(SinavNotlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR tbn)
        {
            db.TBLNOTLAR.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notlar = db.TBLNOTLAR.Find(id);
            return View("NotGetir", notlar);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNOTLAR p, int Sınav1 = 0, int Sınav2 = 0, int Sınav3 = 0, int Proje = 0)
        {
            if (model.islem == "HESAPLA")
            {
                //işlem1
                int ORTALAMA = (Sınav1 + Sınav2 + Sınav3 + Proje) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                //işlem2
                var snv = db.TBLNOTLAR.Find(p.NotID);
                snv.Sınav1 = p.Sınav1;
                snv.Sınav2 = p.Sınav2;
                snv.Sınav3 = p.Sınav3;
                snv.Proje = p.Proje;
                snv.Ortlama = p.Ortlama;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");

            }
            return View();
        
        }
    }
}