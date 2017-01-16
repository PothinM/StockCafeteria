using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StockCafeteria.Dal
{
    public class StockCafeteriaContext:DbContext
    {
        public StockCafeteriaContext() : base("StockCafeteriaContext") {
            //Eager loading, bloque le lazy loading et permet de ne pas tomber dans une boucle infini
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Objet> Objet { get; set; }
        public DbSet<TypeObjet> TypeObjet { get; set; }
        public DbSet<Commande> Commande { get; set; }
        public DbSet<Fournisseur> Fournisseur { get; set; }
        public DbSet<Vente> Vente { get; set; }
        public DbSet<Comptes> Comptes { get; set; }
        public DbSet<Profit> Profit { get; set; }

        
    }
}