using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockCafeteria
{
    public class Objet
    {
        [Key]
        public int IdObjet
        { get; set; }

        public int? IdCommande
        { get; set; }

        [ForeignKey("IdCommande")]
        public virtual Commande Commande
        { get; set; }

        public int? IdTypeObjet
        { get; set; }

        [ForeignKey("IdTypeObjet")]
        public virtual TypeObjet TypeObjet
        { get; set; }

        public bool EstVendu
        { get; set; }
    }
}