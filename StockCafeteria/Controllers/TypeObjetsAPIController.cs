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
    public class TypeObjetsAPIController : ApiController
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: api/TypeObjetsAPI/GetTypeObjet
        [HttpGet]
        public IQueryable<TypeObjet> GetTypeObjet()
        {
            return db.TypeObjet;
        }

        // GET: api/TypeObjetsAPI/GetTypeObjetById/5
        [HttpGet]
        [ResponseType(typeof(TypeObjet))]
        public IHttpActionResult GetTypeObjetById(int param)
        {
            TypeObjet typeObjet = db.TypeObjet.Find(param);
            if (typeObjet == null)
            {
                return NotFound();
            }

            return Ok(typeObjet);
        }

        // PUT: api/TypeObjetsAPI/PutTypeObjet/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeObjet(int param, TypeObjet typeObjet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (param != typeObjet.IdTO)
            {
                return BadRequest();
            }

            db.Entry(typeObjet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeObjetExists(param))
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

        // POST: api/TypeObjetsAPI/PostTypeObjet
        [HttpPost]
        [ResponseType(typeof(TypeObjet))]
        public IHttpActionResult PostTypeObjet(TypeObjet typeObjet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeObjet.Add(typeObjet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { param = typeObjet.IdTO }, typeObjet);
        }

        // DELETE: api/TypeObjetsAPI/DeleteTypeObjet/5
        [HttpDelete]
        [ResponseType(typeof(TypeObjet))]
        public IHttpActionResult DeleteTypeObjet(int param)
        {
            TypeObjet typeObjet = db.TypeObjet.Find(param);
            if (typeObjet == null)
            {
                return NotFound();
            }

            db.TypeObjet.Remove(typeObjet);
            db.SaveChanges();

            return Ok(typeObjet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeObjetExists(int param)
        {
            return db.TypeObjet.Count(e => e.IdTO == param) > 0;
        }
    }
}