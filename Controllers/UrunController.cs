using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var urunler = db.TBLURUNLER.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult Ekle() 
        { 
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=i.KATEGORIAD,
                                                 Value=i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr=degerler;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find (id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction ("Index");  
        }

        public ActionResult UrunGetir(int id)
        {
            var urungetir = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View(urungetir);
        }

        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.URUNID);
                urun.URUNAD = p.URUNAD;
                urun.MARKA = p.MARKA;
                urun.STOK = p.STOK;
                urun.FIYAT = p.FIYAT;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges ();
            return RedirectToAction ("Index");
        }
    }
}