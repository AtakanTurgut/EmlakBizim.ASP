using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using emlakBizim.Models;

namespace emlakBizim.Controllers
{
    public class TipController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Tip
        public ActionResult Index()
        {
            var tips = db.Tips.Include(t => t.Durum);
            return View(tips.ToList());
        }

        public PartialViewResult DurumAd1()
        {
            var durumAd1 = db.Tips.Where(d => d.durumId == 1).FirstOrDefault();

            return PartialView(durumAd1);
        }

        public PartialViewResult DurumAd2()
        {
            var durumAd2 = db.Tips.Where(d => d.durumId == 2).FirstOrDefault();

            return PartialView(durumAd2);
        }

        public PartialViewResult DurumTip1()
        {
            var durumTip1 = db.Tips.Where(d => d.durumId == 1).ToList();

            return PartialView(durumTip1);
        }

        public PartialViewResult DurumTip2()
        {
            var durumTip2 = db.Tips.Where(d => d.durumId == 2).ToList();

            return PartialView(durumTip2);
        }

        // GET: Tip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }

        // GET: Tip/Create
        public ActionResult Create()
        {
            ViewBag.durumId = new SelectList(db.Durums, "durumId", "durumAd");
            return View();
        }

        // POST: Tip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipId,tipAd,durumId")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Tips.Add(tip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.durumId = new SelectList(db.Durums, "durumId", "durumAd", tip.durumId);
            return View(tip);
        }

        // GET: Tip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            ViewBag.durumId = new SelectList(db.Durums, "durumId", "durumAd", tip.durumId);
            return View(tip);
        }

        // POST: Tip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipId,tipAd,durumId")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.durumId = new SelectList(db.Durums, "durumId", "durumAd", tip.durumId);
            return View(tip);
        }

        // GET: Tip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }

        // POST: Tip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tip tip = db.Tips.Find(id);
            db.Tips.Remove(tip);
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
