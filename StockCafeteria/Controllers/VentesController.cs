using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockCafeteria;
using StockCafeteria.Dal;

namespace StockCafeteria.Controllers
{
    public class VentesController : Controller
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: Ventes
        public ActionResult Index()
        {
            var vente = db.Vente.Include(v => v.Objet);
            return View(vente.ToList());
        }

        // GET: Ventes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vente vente = db.Vente.Find(id);
            if (vente == null)
            {
                return HttpNotFound();
            }
            return View(vente);
        }

        // GET: Ventes/Create
        public ActionResult Create()
        {
            ViewBag.IdObjet = new SelectList(db.Objet, "IdObjet", "IdObjet");
            return View();
        }

        // POST: Ventes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVente,DateVente,IdObjet")] Vente vente)
        {
            if (ModelState.IsValid)
            {
                db.Vente.Add(vente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdObjet = new SelectList(db.Objet, "IdObjet", "IdObjet", vente.IdObjet);
            return View(vente);
        }

        // GET: Ventes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vente vente = db.Vente.Find(id);
            if (vente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdObjet = new SelectList(db.Objet, "IdObjet", "IdObjet", vente.IdObjet);
            return View(vente);
        }

        // POST: Ventes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVente,DateVente,IdObjet")] Vente vente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdObjet = new SelectList(db.Objet, "IdObjet", "IdObjet", vente.IdObjet);
            return View(vente);
        }

        // GET: Ventes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vente vente = db.Vente.Find(id);
            if (vente == null)
            {
                return HttpNotFound();
            }
            return View(vente);
        }

        // POST: Ventes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vente vente = db.Vente.Find(id);
            db.Vente.Remove(vente);
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
