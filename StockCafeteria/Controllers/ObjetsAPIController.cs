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
using System.Threading.Tasks;

namespace StockCafeteria.Controllers
{
    public class ObjetsAPIController : ApiController
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: api/ObjetsAPI/GetObjet
        [HttpGet]
        public IQueryable<Objet> GetObjet()
        {
            return db.Objet;
        }

        public class queryStock
        {
            public string Lib { get; set; }
            public int Qte { get; set; }
            public float PrixVente { get; set; }
            public float PrixAchat { get; set; }
        }

        // GET: api/ObjetsAPI/GetStock
        [HttpGet]
        //public IEnumerable<IGrouping<int?, TypeObjet>> GetStock()
        public async Task<IEnumerable<queryStock>> GetStock()
        {
            /*
            var objet = new Objet();
            IEnumerable<IGrouping<int?, int>> query = db.Objet.GroupBy(pet => pet.IdTypeObjet, pet => pet.IdObjet);
            IEnumerable<IGrouping<int?, TypeObjet>> query2 = from pet in db.Objet group pet.TypeObjet by pet.IdTypeObjet;*/

            var result = from i in db.Objet//.Where(x=>x.EstVendu == false)//recupere les objet pas encore vendu
                      //group i by i.TypeObjet.Libelle into g //on les regroupe par leurs type (coca/beignet/plat du jour)
                      group i by i.TypeObjet.Libelle into g //on les regroupe par leurs type (coca/beignet/plat du jour)
                      select new queryStock()//et on attribu les valeurs
                      {
                          Lib = g.Key,
                          Qte = g.Where(x=>x.EstVendu == false).Select(l => l.IdObjet).Distinct().Count(),
                          //prixtest = db.TypeObjet.Where(l=> l.Libelle.Equals(g.Key)).Select(x=>x.PrixAchat).FirstOrDefault()
                          PrixAchat = g.Select(l=>l.TypeObjet.PrixAchat).FirstOrDefault(),
                          PrixVente = g.Select(l=>l.TypeObjet.PrixVente).FirstOrDefault()
                      };
            return await Task.FromResult(result);

            //return query2;

            //var test = db.Objet.Include(x => x.TypeObjet).GroupBy(x=>x.IdTypeObjet);
            //return test;

            //var groupedCustomerList = db.Objet.GroupBy(u => u.IdTypeObjet)
            //                                      .Select(grp => new { GroupID = grp.Key, CustomerList = grp.ToList() })
            //                                      .ToList();
            //return groupedCustomerList


            //var test = (from t in db.Objet
            //            select t).GroupBy(x => x.IdTypeObjet).ToList();
            //return test;

            //return db.Objet.Include(x => x.TypeObjet).GroupBy(x => x.IdTypeObjet).Select(to => to.ToList()).ToList();
            //var d = from m in db.Objet.Include(x => x.IdTypeObjet) group m.IdObjet by m.IdTypeObjet into g;

            //var group = db.Objet.GroupBy(i => i);
            //var result = db.Objet.GroupBy(n => n.IdTypeObjet)
            //    .Select(c => new { Key = c.Key, Qte = c.Count() });
            //return result.ToList();

        }

        // GET: api/ObjetsAPI/GetQuantite/5
        [HttpGet]
        [ResponseType(typeof(int))]
        public IHttpActionResult GetQuantite(int param)
        {
            return Ok(db.Objet.Count(e => e.IdTypeObjet == param));
        }

        // GET: api/ObjetsAPI/GetObjetById/5
        [HttpGet]
        [ResponseType(typeof(Objet))]
        public IHttpActionResult GetObjetById(int param)
        {
            Objet objet = db.Objet.Find(param);
            if (objet == null)
            {
                return NotFound();
            }

            return Ok(objet);
        }

        // PUT: api/ObjetsAPI/PutObjet/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutObjet(int param, Objet objet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (param != objet.IdObjet)
            {
                return BadRequest();
            }

            db.Entry(objet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetExists(param))
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

        // POST: api/ObjetsAPI/PostObjet
        [HttpPost]
        [ResponseType(typeof(Objet))]
        public IHttpActionResult PostObjet(Objet objet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Objet.Add(objet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { param = objet.IdObjet }, objet);
        }

        // DELETE: api/ObjetsAPI/DeleteObjet/5
        [HttpDelete]
        [ResponseType(typeof(Objet))]
        public IHttpActionResult DeleteObjet(int param)
        {
            Objet objet = db.Objet.Find(param);
            if (objet == null)
            {
                return NotFound();
            }

            db.Objet.Remove(objet);
            db.SaveChanges();

            return Ok(objet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObjetExists(int param)
        {
            return db.Objet.Count(e => e.IdObjet == param) > 0;
        }
    }
}