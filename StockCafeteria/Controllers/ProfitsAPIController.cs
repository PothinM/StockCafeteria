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
    public class ProfitsAPIController : ApiController
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: api/ProfitsAPI/GetProfit
        [HttpGet]
        public IQueryable<Profit> GetProfit()
        {
            return db.Profit;
        }

        public class queryProfit
        {
            public float Depenses { get; set; }
            public float Ventes { get; set; }
            public float Benefices { get; set; }
        }

        // GET: api/ProfitsAPI/Calculer
        [HttpGet]
        public queryProfit Calculer(string param)
        {
            string dtDeb;
            string dtFin;
            var chaine = param.ToString().Split('T');
            
            dtDeb = chaine[0];
            dtFin = chaine[1];
            DateTime dateDebut = DateTime.Parse(dtDeb);
            DateTime dateFin = DateTime.Parse(dtFin);

            var result = new queryProfit();
            var listDepenses = db.Commande.Where(x => x.dateCommande >= dateDebut && x.dateCommande <= dateFin)
                .Select(x => x.SommeCommande).ToList();
            foreach (var item in listDepenses)
            {
                result.Depenses += item;
            }
            var listVentes = db.Vente.Where(x => x.DateVente >= dateDebut && x.DateVente <= dateFin)
                .Select(x => x.Objet.TypeObjet.PrixVente).ToList();
            foreach (var item in listVentes)
            {
                result.Ventes += item;
            }
            //result.Depenses = 100;
            //result.Ventes = 150;
            /*sresult.Depenses = float.Parse(chaine[0]);
            result.Ventes = float.Parse(chaine[1]);*/

            result.Benefices = result.Ventes - result.Depenses;

            return result;
        }


        // GET: api/ProfitsAPI/GetProfit/5
        [HttpGet]
        [ResponseType(typeof(Profit))]
        public IHttpActionResult GetProfitById(int param)
        {
            Profit profit = db.Profit.Find(param);
            if (profit == null)
            {
                return NotFound();
            }

            return Ok(profit);
        }

        // PUT: api/ProfitsAPI/PutProfit/5
        [HttpGet]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfit(int param, Profit profit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (param != profit.IdProfit)
            {
                return BadRequest();
            }

            db.Entry(profit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfitExists(param))
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

        // POST: api/ProfitsAPI/PostProfit
        [HttpPost]
        [ResponseType(typeof(Profit))]
        public IHttpActionResult PostProfit(Profit profit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profit.Add(profit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profit.IdProfit }, profit);
        }

        // DELETE: api/ProfitsAPI/DeleteProfit/5
        [HttpDelete]
        [ResponseType(typeof(Profit))]
        public IHttpActionResult DeleteProfit(int param)
        {
            Profit profit = db.Profit.Find(param);
            if (profit == null)
            {
                return NotFound();
            }

            db.Profit.Remove(profit);
            db.SaveChanges();

            return Ok(profit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfitExists(int id)
        {
            return db.Profit.Count(e => e.IdProfit == id) > 0;
        }
    }
}