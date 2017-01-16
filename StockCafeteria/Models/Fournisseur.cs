using System.ComponentModel.DataAnnotations;

namespace StockCafeteria
{
    public class Fournisseur
    {
        [Key]
        public int IdFournisseur
        { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Nom
        { get; set; }

        [MaxLength(50)]
        public string Adresse
        { get; set; }
    }
}