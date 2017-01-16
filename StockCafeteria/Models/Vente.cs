using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockCafeteria
{
    public class Vente
    {
        [Key]
        public int IdVente
        { get; set; }

        [Required]
        public DateTime DateVente
        { get; set; }

        public int? IdObjet
        { get; set; }

        [ForeignKey("IdObjet")]
        public virtual Objet Objet
        { get; set; }
    }
}