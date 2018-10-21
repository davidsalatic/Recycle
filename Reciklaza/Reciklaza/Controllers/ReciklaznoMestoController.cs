using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Reciklaza.Data;
using Reciklaza.Data.Models;

namespace Reciklaza.Controllers
{
    public class ReciklaznoMestoController : Controller
    {
        private ReciklazaContext db = new ReciklazaContext();


        public ActionResult Index()
        {
            return View(db.ReciklaznaMesta.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReciklaznoMesto reciklaznoMesto = db.ReciklaznaMesta.Find(id);
            if (reciklaznoMesto == null)
            {
                return HttpNotFound();
            }
            return View(reciklaznoMesto);
        }
        

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Grad,Adresa,Telefon,Email,Website,NazivMaterijala,CenaPoKg")] ReciklaznoMesto reciklaznoMesto)
        {
            if (ModelState.IsValid)
            {
                db.ReciklaznaMesta.Add(reciklaznoMesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(reciklaznoMesto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReciklaznoMesto reciklaznoMesto = db.ReciklaznaMesta.Find(id);
            if (reciklaznoMesto == null)
            {
                return HttpNotFound();
            }
            return View(reciklaznoMesto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Grad,Adresa,Telefon,Email,Website,NazivMaterijala,CenaPoKg")] ReciklaznoMesto reciklaznoMesto)
        { 
            if (ModelState.IsValid)
            {
                db.Entry(reciklaznoMesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reciklaznoMesto);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReciklaznoMesto reciklaznoMesto = db.ReciklaznaMesta.Find(id);
            if (reciklaznoMesto == null)
            {
                return HttpNotFound();
            }
            return View(reciklaznoMesto);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReciklaznoMesto reciklaznoMesto = db.ReciklaznaMesta.Find(id);
            db.ReciklaznaMesta.Remove(reciklaznoMesto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Filter(ReciklaznoMestoFilter filter)
        {
            var products = from s in db.ReciklaznaMesta
                                          select s;

            if (!filter.Grad.IsNullOrWhiteSpace())
            {
                products = products.Where(p => p.Grad.Contains(filter.Grad));
            }

            return View(products.ToList());
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
