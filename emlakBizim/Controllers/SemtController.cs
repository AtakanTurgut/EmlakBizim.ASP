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
    public class SemtController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Semt
        public ActionResult Index()
        {
            var semts = db.Semts.Include(s => s.Sehir);
            return View(semts.ToList());
        }

        // GET: Semt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semt semt = db.Semts.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            return View(semt);
        }

        // GET: Semt/Create
        public ActionResult Create()
        {
            ViewBag.sehirId = new SelectList(db.Sehirs, "sehirId", "sehirAd");
            return View();
        }

        // POST: Semt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "semtId,semtAd,sehirId")] Semt semt)
        {
            if (ModelState.IsValid)
            {
                db.Semts.Add(semt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sehirId = new SelectList(db.Sehirs, "sehirId", "sehirAd", semt.sehirId);
            return View(semt);
        }

        // GET: Semt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semt semt = db.Semts.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            ViewBag.sehirId = new SelectList(db.Sehirs, "sehirId", "sehirAd", semt.sehirId);
            return View(semt);
        }

        // POST: Semt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "semtId,semtAd,sehirId")] Semt semt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sehirId = new SelectList(db.Sehirs, "sehirId", "sehirAd", semt.sehirId);
            return View(semt);
        }

        // GET: Semt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semt semt = db.Semts.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            return View(semt);
        }

        // POST: Semt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semt semt = db.Semts.Find(id);
            db.Semts.Remove(semt);
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
