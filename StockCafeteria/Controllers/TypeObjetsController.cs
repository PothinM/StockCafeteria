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
    public class TypeObjetsController : Controller
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: TypeObjets
        public ActionResult Index()
        {
            return View(db.TypeObjet.ToList());
        }

        // GET: TypeObjets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeObjet typeObjet = db.TypeObjet.Find(id);
            if (typeObjet == null)
            {
                return HttpNotFound();
            }
            return View(typeObjet);
        }

        // GET: TypeObjets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeObjets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTO,Libelle,PrixVente")] TypeObjet typeObjet)
        {
            if (ModelState.IsValid)
            {
                db.TypeObjet.Add(typeObjet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeObjet);
        }

        // GET: TypeObjets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeObjet typeObjet = db.TypeObjet.Find(id);
            if (typeObjet == null)
            {
                return HttpNotFound();
            }
            return View(typeObjet);
        }

        // POST: TypeObjets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTO,Libelle,PrixVente")] TypeObjet typeObjet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeObjet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeObjet);
        }

        // GET: TypeObjets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeObjet typeObjet = db.TypeObjet.Find(id);
            if (typeObjet == null)
            {
                return HttpNotFound();
            }
            return View(typeObjet);
        }

        // POST: TypeObjets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeObjet typeObjet = db.TypeObjet.Find(id);
            db.TypeObjet.Remove(typeObjet);
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
