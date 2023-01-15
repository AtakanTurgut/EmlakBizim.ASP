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
    public class MahalleController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Mahalle
        public ActionResult Index()
        {
            var mahalles = db.Mahalles.Include(m => m.Semt);
            return View(mahalles.ToList());
        }

        // GET: Mahalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahalle mahalle = db.Mahalles.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        // GET: Mahalle/Create
        public ActionResult Create()
        {
            ViewBag.semtId = new SelectList(db.Semts, "semtId", "semtAd");
            return View();
        }

        // POST: Mahalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahalleId,mahalleAd,semtId")] Mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                db.Mahalles.Add(mahalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.semtId = new SelectList(db.Semts, "semtId", "semtAd", mahalle.semtId);
            return View(mahalle);
        }

        // GET: Mahalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahalle mahalle = db.Mahalles.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.semtId = new SelectList(db.Semts, "semtId", "semtAd", mahalle.semtId);
            return View(mahalle);
        }

        // POST: Mahalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahalleId,mahalleAd,semtId")] Mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.semtId = new SelectList(db.Semts, "semtId", "semtAd", mahalle.semtId);
            return View(mahalle);
        }

        // GET: Mahalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahalle mahalle = db.Mahalles.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        // POST: Mahalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mahalle mahalle = db.Mahalles.Find(id);
            db.Mahalles.Remove(mahalle);
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
