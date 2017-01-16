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
    public class VentesAPIController : ApiController
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: api/VentesAPI/GetVente
        [HttpGet]
        public IQueryable<Vente> GetVente()
        {
            return db.Vente.Include(x=>x.Objet.TypeObjet);
        }

        // GET: api/VentesAPI/GetVenteById/5
        [HttpGet]
        [ResponseType(typeof(Vente))]
        public IHttpActionResult GetVenteById(int param)
        {
            Vente vente = db.Vente.Find(param);
            if (vente == null)
            {
                return NotFound();
            }

            return Ok(vente);
        }

        // GET: api/VentesAPI/AnnulerVenteById/5
        [HttpDelete]
        [ResponseType(typeof(Vente))]
        public IHttpActionResult AnnulerVenteById(int param)
        {
            Vente vente = db.Vente.Find(param);
            Objet objet = db.Objet.Find(vente.IdObjet);
            if (vente == null && objet == null)
            {
                return NotFound();
            }

            db.Vente.Remove(vente);
            //db.Entry(objet).Entity.EstVendu = false;
            objet.EstVendu = false;
            db.SaveChanges();

            return Ok(vente);
        }

        // PUT: api/VentesAPI/PutVente/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVente(int param, Vente vente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (param != vente.IdVente)
            {
                return BadRequest();
            }

            db.Entry(vente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenteExists(param))
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

        // POST: api/VentesAPI/PostVente
        [HttpPost]
        [ResponseType(typeof(Vente))]
        public IHttpActionResult PostVente(Vente vente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vente.Add(vente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vente.IdVente }, vente);
        }

        // DELETE: api/VentesAPI/DeleteVente/5
        [HttpDelete]
        [ResponseType(typeof(Vente))]
        public IHttpActionResult DeleteVente(int param)
        {
            Vente vente = db.Vente.Find(param);
            if (vente == null)
            {
                return NotFound();
            }

            db.Vente.Remove(vente);
            db.SaveChanges();

            return Ok(vente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VenteExists(int id)
        {
            return db.Vente.Count(e => e.IdVente == id) > 0;
        }
    }
}