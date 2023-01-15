using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using emlakBizim.Models;

namespace emlakBizim.Controllers
{
    public class IlanController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ilan
        public ActionResult Index()
        {
            var userName = User.Identity.Name;

            var ilans = db.Ilans.Where(u => u.userName == userName).Include(i => i.Mahalle).Include(i => i.Tip);
            return View(ilans.ToList());
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

        public ActionResult Images(int id)
        {
            var ilan = db.Ilans.Where(i => i.ilanId == id).ToList();
            var imgs = db.Resims.Where(i => i.ilanId == id).ToList();
            ViewBag.imgs = imgs;
            ViewBag.ilan = ilan;

            return View();
        }

        [HttpPost]
        public ActionResult Images(int id, HttpPostedFileBase file)
        {
            string path = Path.Combine("/Content/images/" + file.FileName);
            file.SaveAs(Server.MapPath(path));

            Resim rsm = new Resim();
            rsm.resimAd = file.FileName.ToString();
            rsm.ilanId = id;
            db.Resims.Add(rsm);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Ilan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: Ilan/Create
        public ActionResult Create()
        {
            ViewBag.sehirList = new SelectList(SehirGetir(), "sehirId", "sehirAd");
            ViewBag.durumList = new SelectList(DurumGetir(), "durumId", "durumAd");

            return View();
        }

        // POST: Ilan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ilanId,acıklama,fiyat,odaSayisi,banyoSayisi,kredi,alan,kat,telefon,adres,userName,sehirId,semtId,durumId,mahalleId,tipId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                ilan.userName = User.Identity.Name;
                db.Ilans.Add(ilan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sehirList = new SelectList(SehirGetir(), "sehirId", "sehirAd");
            ViewBag.durumList = new SelectList(DurumGetir(), "durumId", "durumAd");

            return View(ilan);
        }

        // GET: Ilan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }

            ViewBag.sehirList = new SelectList(SehirGetir(), "sehirId", "sehirAd");
            ViewBag.durumList = new SelectList(DurumGetir(), "durumId", "durumAd");
            ViewBag.semtId = new SelectList(db.Semts, "semtId", "semtAd", ilan.semtId);

            ViewBag.mahalleId = new SelectList(db.Mahalles, "mahalleId", "mahalleAd", ilan.mahalleId);
            ViewBag.tipId = new SelectList(db.Tips, "tipId", "tipAd", ilan.tipId);
            return View(ilan);
        }

        // POST: Ilan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ilanId,acıklama,fiyat,odaSayisi,banyoSayisi,kredi,alan,kat,telefon,adres,userName,sehirId,semtId,durumId,mahalleId,tipId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sehirList = new SelectList(SehirGetir(), "sehirId", "sehirAd");
            ViewBag.durumList = new SelectList(DurumGetir(), "durumId", "durumAd");

            return View(ilan);
        }

        // GET: Ilan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Ilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = db.Ilans.Find(id);
            db.Ilans.Remove(ilan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
