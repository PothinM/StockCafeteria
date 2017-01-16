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
    public class CommandesAPIController : ApiController
    {
        private StockCafeteriaContext db = new StockCafeteriaContext();

        // GET: api/CommandesAPI/GetCommande
        [HttpGet]
        public IQueryable<Commande> GetCommande()
        {
            return db.Commande;
        }

        // GET: api/CommandesAPI/GetCommandeById/5
        [HttpGet]
        [ResponseType(typeof(Commande))]
        public IHttpActionResult GetCommandeById(int param)
        {
            Commande commande = db.Commande.Find(param);
            if (commande == null)
            {
                return NotFound();
            }

            return Ok(commande);
        }

        // PUT: api/CommandesAPI/PutCommande/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommande(int param, Commande commande)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (param != commande.IdCommande)
            {
                return BadRequest();
            }

            db.Entry(commande).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(param))
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

        public class objetCommande
        {
            public string libTO { get; set; }
            public int qte { get; set; }
        }

        public class postCommandeRequest
        {
            public Commande commande { get; set; }
            public List<objetCommande> objets { get; set; }
            //public DateTime date { get; set; }
        }

        // POST: api/CommandesAPI/PostCommande
        [HttpPost]
        [ResponseType(typeof(Commande))]
        //public IHttpActionResult PostCommande(Commande commande, List<objetCommande> objets)
        public IHttpActionResult PostCommande([FromBody] postCommandeRequest parameters)
        {
            //var test = DateTime.Parse(parameters.date);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commande = parameters.commande;
            var objets = parameters.objets;

            db.Commande.Add(commande);//on ajoute la commande puis

            foreach (var item in objets)//pour chaque objet dans la liste des nouveaux objets :
            {                
                for (int i = 0; i < item.qte; i++)//en fonction de la quantité on ajoute x nombre de cet objet
                {
                    Objet newObj = new Objet//on créer un objet avec la commande renseigné
                    {
                        Commande = commande,
                        EstVendu = false,
                        IdCommande = commande.IdCommande,
                        IdTypeObjet = db.TypeObjet.Where(x => x.Libelle == item.libTO).Select(l => l.IdTO).FirstOrDefault()
                    };
                    db.Objet.Add(newObj);
                }
            }

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { param = commande.IdCommande }, commande);
        }

        // DELETE: api/CommandesAPI/DeleteCommande/5
        [HttpDelete]
        [ResponseType(typeof(Commande))]
        public IHttpActionResult DeleteCommande(int param)
        {
            Commande commande = db.Commande.Find(param);//on cherche la commande
            if (commande == null)
            {
                return NotFound();//elle n'existe pas -> on sort
            }

            //on cherche les objets de cette commande
            var objetsCommande = db.Objet.Where(x => x.IdCommande == commande.IdCommande).ToList();
            foreach (var item in objetsCommande)//pour chaque objet trouvé:
            {
                if(item.EstVendu == true)//s'il est vendu -> on supprime la vente puis
                {
                    var vente = db.Vente.Where(x => x.IdObjet == item.IdObjet).FirstOrDefault();
                    db.Vente.Remove(vente);

                }
                db.Objet.Remove(item); //on supprime l'objet
            }

            db.Commande.Remove(commande); //puis la commande
            db.SaveChanges(); //et on sauvegarde les changements

            return Ok(commande);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommandeExists(int param)
        {
            return db.Commande.Count(e => e.IdCommande == param) > 0;
        }
    }
}