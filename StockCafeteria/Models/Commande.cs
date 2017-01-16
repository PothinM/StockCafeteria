using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockCafeteria
{
    public class Commande
    {
        [Key]
        public int IdCommande
        { get; set; }

        [Required]
        public float SommeCommande
        { get; set; }

        [Required]
        public int IdFournisseur
        { get; set; }

        [ForeignKey("IdFournisseur")]
        public virtual Fournisseur Fournisseur
        { get; set; }

        public List<Objet> Objets
        { get; set; }

        [Required()]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime dateCommande
        { get; set; }
    }
}