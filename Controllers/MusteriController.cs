using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var musteri = db.TBLMUSTERILER.ToList();
            return View(musteri);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }

            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult MusteriGetir(int id)
        {
            var mstrgetir = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",mstrgetir);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteriguncelle = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteriguncelle.MUSTERIID = p1.MUSTERIID;
            musteriguncelle.MUSTERIAD = p1.MUSTERIAD;
            musteriguncelle.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}