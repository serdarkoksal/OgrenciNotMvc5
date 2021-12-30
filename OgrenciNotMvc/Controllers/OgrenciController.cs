using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities(); 
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCİLER.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKLUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KlupAd,
                                                 Value = i.KlupID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCİLER p3)
        {
            var klp = db.TBLKLUPLER.Where(m => m.KlupID == p3.TBLKLUPLER.KlupID).FirstOrDefault();
            p3.TBLKLUPLER = klp;
            db.TBLOGRENCİLER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCİLER.Find(id);
            db.TBLOGRENCİLER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCİLER.Find(id);
            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TBLOGRENCİLER p)
        {
            var ogr = db.TBLOGRENCİLER.Find(p.OgrenciID);
            ogr.OgrAd = p.OgrAd;
            ogr.OgrSoyad = p.OgrSoyad;
            ogr.OgrFoto = p.OgrFoto;
            ogr.OgrCinsiyet = p.OgrCinsiyet;
            ogr.OgrKlup = p.OgrKlup;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}


//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

//items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

//items.Add(new SelectListItem { Text = "Atatürk İlke ve İnkılapları", Value = "2" });

//items.Add(new SelectListItem { Text = "Coğrafya", Value = "3" });

//items.Add(new SelectListItem { Text = "Edebiyat", Value = "3" });


//ViewBag.DersAd = items;