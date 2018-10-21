using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reciklaza.Data;
using Reciklaza.Data.Models;

namespace Reciklaza.Controllers
{
    public class MaterijalController : Controller
    {
        private ReciklazaContext db = new ReciklazaContext();


        public ActionResult Index()
        {
            return View(db.Materijals.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv")] Materijal materijal)
        {
            if (ModelState.IsValid)
            {
                db.Materijals.Add(materijal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materijal);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materijal materijal = db.Materijals.Find(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View(materijal);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv")] Materijal materijal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materijal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materijal);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materijal materijal = db.Materijals.Find(id);
            if (materijal == null)
            {
                return HttpNotFound();
            }
            return View(materijal);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materijal materijal = db.Materijals.Find(id);
            db.Materijals.Remove(materijal);
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
