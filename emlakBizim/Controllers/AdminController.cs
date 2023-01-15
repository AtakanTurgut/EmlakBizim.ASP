using emlakBizim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace emlakBizim.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IlanListesi()
        {
            var ilan = db.Ilans.Include(x => x.Mahalle).Include(x => x.Tip).ToList();

            return View(ilan);
        }

        //

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = db.Ilans.Find(id);
            db.Ilans.Remove(ilan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}