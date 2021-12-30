using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class KluplerController : Controller
    {
        // GET: Klupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var klupler = db.TBLKLUPLER.ToList();
            return View(klupler);
        }
        [HttpGet]
        public ActionResult YeniKlup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKlup(TBLKLUPLER p2)
        {
            db.TBLKLUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var klup = db.TBLKLUPLER.Find(id);
            db.TBLKLUPLER.Remove(klup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KlupGetir(int id)
        {
            var klup = db.TBLKLUPLER.Find(id);

            return View("KlupGetir",klup);
        }
        public ActionResult Guncelle(TBLKLUPLER p)
        {
            var klp = db.TBLKLUPLER.Find(p.KlupID);
            klp.KlupAd = p.KlupAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Klupler");
        }
    }
}