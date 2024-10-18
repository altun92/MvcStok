using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            var liste = db.TBLSATİSLAR.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATİSLAR p)
        {
            db.TBLSATİSLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}