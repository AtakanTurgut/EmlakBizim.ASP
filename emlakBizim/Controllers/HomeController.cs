using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emlakBizim.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace emlakBizim.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        
        // GET: Home
        public ActionResult Index(int number = 1)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;

            var ilan = db.Ilans.Include(m => m.Mahalle).Include(t => t.Tip);

            return View(ilan.ToList().ToPagedList(number, 3));
        }

        public ActionResult DurumList(int id)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;

            var ilan = db.Ilans.Where(i => i.durumId == id).Include(m => m.Mahalle).Include(t => t.Tip);

            return View(ilan.ToList());
        }

        public ActionResult MenuFilter(int id)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;

            var filter = db.Ilans.Where(t => t.tipId == id).Include(m => m.Mahalle).Include(t => t.Tip).ToList();

            return View(filter);
        }

        public PartialViewResult PartialFilter()
        {
            ViewBag.sehirList = new SelectList(SehirGetir(), "sehirId", "sehirAd");
            ViewBag.durumList = new SelectList(DurumGetir(), "durumId", "durumAd");

            return PartialView();
        }

        public ActionResult Filter(int min, int max, int sehirId, int mahalleId, int semtId, int durumId, int tipId)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;

            var filter = db.Ilans.Where(x => x.fiyat >= min && x.fiyat <= max &&
                                        x.durumId == durumId && x.semtId == semtId &&
                                        x.mahalleId == mahalleId && x.sehirId == sehirId &&
                                        x.tipId == tipId).Include(m => m.Mahalle).Include(t => t.Tip).ToList();
            return View(filter);
        }

        public List<Sehir> SehirGetir()
        {
            List<Sehir> sehirler = db.Sehirs.ToList();

            return sehirler;
        }

        public ActionResult SemtGetir(int sehirId)
        {
            List<Semt> semtler = db.Semts.Where(s => s.sehirId == sehirId).ToList();
            ViewBag.semtlistesi = new SelectList(semtler, "semtId", "semtAd");

            return PartialView("SemtPartial");
        }

        public ActionResult MahalleGetir(int semtId)
        {
            List<Mahalle> mahalleler = db.Mahalles.Where(s => s.semtId == semtId).ToList();
            ViewBag.mahalleListesi = new SelectList(mahalleler, "mahalleId", "mahalleAd");

            return PartialView("MahallePartial");
        }

        public List<Durum> DurumGetir()
        {
            List<Durum> durumlar = db.Durums.ToList();

            return durumlar;
        }

        public ActionResult TipGetir(int durumId)
        {
            List<Tip> tipler = db.Tips.Where(d => d.durumId == durumId).ToList();
            ViewBag.tipListesi = new SelectList(tipler, "tipId", "tipAd");

            return PartialView("TipPartial");
        }


        public ActionResult Search(string e)
        {
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;
            var src = db.Ilans.Include(m => m.Mahalle).Include(t => t.Tip);
            
            if (!string.IsNullOrEmpty(e))
            {
                src = src.Where(a => a.acıklama.Contains(e) || a.Mahalle.mahalleAd.Contains(e) 
                                  || a.Tip.tipAd.Contains(e));
            }

            return View(src.ToList());
        }

        public ActionResult Detay(int id)
        {
            var ilan = db.Ilans.Where(i => i.ilanId == id).Include(m => m.Mahalle).Include(t => t.Tip).FirstOrDefault();
            var imgs = db.Resims.Where(i => i.ilanId == id).ToList();
            ViewBag.imgs = imgs;

            return View(ilan);
        }

        public PartialViewResult Slider()
        {
            var ilan = db.Ilans.ToList().Take(5);
            var imgs = db.Resims.ToList();
            ViewBag.imgs = imgs;

            return PartialView(ilan);
        }
    }
}