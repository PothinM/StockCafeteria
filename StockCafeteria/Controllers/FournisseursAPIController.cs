using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StockCafeteria;
using StockCafeteria.Dal;

namespace StockCafeteria.Controllers
{
    public class FournisseursAPIController : ApiController
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: api/FournisseursAPI/GetFournisseur
        [HttpGet]
        public IQueryable<Fournisseur> GetFournisseur()
        {
            return db.Fournisseur;
        }

        // GET: api/FournisseursAPI/GetFournisseurById/5
        [HttpGet]
        [ResponseType(typeof(Fournisseur))]
        public IHttpActionResult GetFournisseurById(int id)
        {
            Fournisseur fournisseur = db.Fournisseur.Find(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            return Ok(fournisseur);
        }

        // PUT: api/FournisseursAPI/PutFournisseur/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFournisseur(int id, Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fournisseur.IdFournisseur)
            {
                return BadRequest();
            }

            db.Entry(fournisseur).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FournisseurExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FournisseursAPI/PostFournisseur
        [HttpPost]
        [ResponseType(typeof(Fournisseur))]
        public IHttpActionResult PostFournisseur(Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fournisseur.Add(fournisseur);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fournisseur.IdFournisseur }, fournisseur);
        }

        // DELETE: api/FournisseursAPI/DeleteFournisseur/5
        [HttpDelete]
        [ResponseType(typeof(Fournisseur))]
        public IHttpActionResult DeleteFournisseur(int id)
        {
            Fournisseur fournisseur = db.Fournisseur.Find(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            db.Fournisseur.Remove(fournisseur);
            db.SaveChanges();

            return Ok(fournisseur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FournisseurExists(int id)
        {
            return db.Fournisseur.Count(e => e.IdFournisseur == id) > 0;
        }
    }
}